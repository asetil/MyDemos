using Aware.Auth;
using Aware.BL.Model;
using Aware.Model;
using Aware.Search;
using Aware.Util;
using Aware.Util.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.Controllers;

public class AccountController(IUserManager userManager) : AwareEmptyController<UserItemDto>(userManager)
{
    [HttpPost("login")]
    [AllowAnonymous]
    public OperationResult<SessionItemDto> Login([FromBody] LoginItemDto model)
    {
        var loginResult = userManager.Login(model.Username, model.Password);

        return loginResult;
    }

    [HttpPost]
    [Authorize]
    public OperationResult<bool> Logout()
    {
        if (CurrentUserId > 0)
            return userManager.Logout(CurrentUserId);

        return Failed<bool>(ResultCodes.Error.Login.LogoffFailed);
    }

    [HttpGet("user-list")]
    [Authorize]
    public SearchResult<UserItemDto> GetUserList([FromQuery] SearchParams<UserItemDto> searchParams)
    {
        var result = userManager.Search(searchParams);
        return result;
    }
}
