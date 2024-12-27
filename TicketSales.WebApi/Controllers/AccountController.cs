using Aware.Auth;
using Aware.Model;
using Aware.Search;
using Aware.Util;
using Aware.Util.Cache;
using Aware.Util.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.Controllers;

public class AccountController(IUserManager userManager, IActivationDataManager activationDataManager, IAwareCacher cacher) : AwareEmptyController
{
    [HttpPost("login")]
    [AllowAnonymous]
    public OperationResult<SessionItemDto> Login([FromBody] LoginItemDto model)
    {
        if (CurrentUserId > 0)
            return Failed<SessionItemDto>(ResultCodes.Error.Login.AlreadyLoggedIn);

        var loginResult = userManager.Login(model.Username, model.Password);

        return loginResult;
    }

    [HttpPost("register")]
    [Authorize]
    public OperationResult<bool> Register([FromBody] UserItemDto model)
    {
        if (CurrentUserId > 0)
            return Failed<bool>(ResultCodes.Error.Login.AlreadyLoggedIn);

        var result = userManager.Register(model);

        return result;
    }

    [HttpPost("logout")]
    [Authorize]
    public OperationResult<bool> Logout()
    {
        if (CurrentUserId > 0)
            return userManager.Logout(CurrentUserId);

        return Failed<bool>(ResultCodes.Error.Login.LogoffFailed);
    }

    [HttpPost("activation")]
    public OperationResult<ActivationDataItemDto> Activation([FromQuery] string code)
    {
        if (string.IsNullOrEmpty(code))
            return Failed<ActivationDataItemDto>(ResultCodes.Error.ActivationData.InvalidActivationCode);

        var result = activationDataManager.CheckCode(code);

        return result;
    }

    [HttpGet("user-list")]
    [Authorize]
    public SearchResult<UserItemDto> GetUserList([FromQuery] SearchParams<UserItemDto> searchParams)
    {
        var result = userManager.Search(searchParams);
        return result;
    }

    /// <summary>
    /// FOR DEVELOPMENT PURPOSES ONLY!!!
    /// Replace user name and password with your own
    /// </summary>
    /// <returns></returns>
    [HttpGet("login-demo")]
    public OperationResult<SessionItemDto> LoginDemo()
    {
        if (CurrentUserId > 0)
            return Failed<SessionItemDto>(ResultCodes.Error.Login.AlreadyLoggedIn);

        var loginResult = userManager.Login("admin@ticketsales.com", "admin");
        if (loginResult.Ok)
        {
            cacher.Add("DEMO_SESSION_TOKEN", loginResult.Value.SessionToken, CommonConstants.HourlyCacheTime);
        }

        return loginResult;
    }
}
