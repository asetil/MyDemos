using Aware.Manager;
using Aware.Util;
using Aware.Util.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TicketSales.WebApi.BusinessLogic.Util;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.Controllers;

public class HomeController(IMenuItemManager menuItemManager, ISliderItemManager sliderItemManager) : AwareEmptyController
{
    [HttpGet("get-menu")]
    [OutputCache(Duration = CommonConstants.HourlyCacheTime)]
    public List<MenuItemDto> GetMenu()
    {
        return menuItemManager.GetCachedMenu();
    }

    [HttpGet("get-slider")]
    public List<SliderItemDto> GetHomeSlider()
    {
        return sliderItemManager.GetByType((int)SliderType.Home);
    }
}
