using Aware.Util.Web;
using Microsoft.AspNetCore.Mvc;
using TicketSales.WebApi.BusinessLogic.SearchParams;
using TicketSales.WebApi.BusinessLogic.Services;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.Controllers;

/// <summary>
/// Check event controller methods on swagger
/// </summary>
/// <param name="eventService"></param>
/// <param name="eventSessionService"></param>
public class EventController(IEventService eventService, IEventSessionService eventSessionService) : AwareAuthorizedSearchController<EventItemDto, EventSearchParams>(eventService)
{
    [HttpGet("places/{eventId}")]
    public List<PlaceItemDto> GetEventPlaces(long eventId)
    {
        var result = eventSessionService.GetEventPlaces(eventId);

        return result;
    }

    [HttpGet("event-live")]
    public ContentResult EventLive()
    {
        var html = System.IO.File.ReadAllText(@"./event-live.html");
        return base.Content(html, "text/html");
    }

    [HttpGet("publish")]
    public ActionResult PublishEvent()
    {
        var id = new Random().Next(1000, 99999);
        eventService.PublishEvent(new EventItemDto()
        {
            Id = id,
            Name = "My Test Event " + id
        });

        return new JsonResult(true);
    }
}
