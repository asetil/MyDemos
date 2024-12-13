using Aware.Util.Constants;
using Aware.Util.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using TicketSales.WebApi.BusinessLogic.Services;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.Controllers;

public class EventOrganizerController(IEventOrganizerService service) : AwareAuthorizedController<EventOrganizerItemDto>(service)
{
    [HttpGet("top-list")]
    [OutputCache(Duration =  CommonConstants.HourlyCacheTime)]
    public List<EventOrganizerItemDto> GetTopList()
    {
        return service.GetTopList();
    }
}
