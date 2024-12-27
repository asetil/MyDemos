using Aware.Model;
using Aware.Util.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSales.WebApi.BusinessLogic.Services;
using TicketSales.WebApi.Model.Dto;
using Worchart.Search;

namespace TicketSales.WebApi.Controllers;

/// <summary>
/// Check event controller methods on swagger
/// </summary>
/// <param name="eventService"></param>
/// <param name="eventPlaceService"></param>
public class EventController(IEventService eventService, IEventPlaceService eventPlaceService) : AwareAuthorizedSearchController<EventItemDto, EventSearchParams>(eventService)
{

    [HttpGet("places/{eventId}")]
    public List<PlaceItemDto> GetEventPlaces(long eventId)
    {
        var result = new List<PlaceItemDto>();

        //If you use Aware entities then you can access to current user information
        var userId = CurrentUserId;
        if (userId == 0)
        {
            var searchResult = eventPlaceService.SearchBy(p => p.EventId == eventId, page: 1, pageSize: 100);
            if (searchResult.HasResult)
                result = searchResult.Results.Select(s => s.Place).ToList();
        }
        else
        {
            var searchParams = new EventPlaceSearchParams()
            {
                EventId = eventId,
                UserId = userId,
            };

            searchParams.WithCount();
            searchParams.SetPaging(1, 1);

            var searchResult = eventPlaceService.Search(searchParams);
            if (searchResult.HasResult)
                result = searchResult.Results.Select(s => s.Place).ToList();
        }

        return result;
    }

    [HttpGet("buy-ticket/{eventId}")]
    [Authorize]
    public OperationResult<bool> BuyTicket(long eventId)
    {
        return Success<bool>(true);
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
