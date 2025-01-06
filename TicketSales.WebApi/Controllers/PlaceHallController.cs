using Aware.Util.Web;
using Microsoft.AspNetCore.Mvc;
using TicketSales.WebApi.BusinessLogic.Services;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.Controllers;

public class PlaceHallController(IPlaceHallService placeHallService, IPlaceHallSeatService seatService) : AwareAuthorizedController<PlaceHallItemDto>(placeHallService)
{
    [HttpGet("seats/{placeHallId}")]
    public List<PlaceHallSeatItemDto> GetSeats(long placeHallId)
    {
        var result = seatService.SearchBy(p => p.PlaceHallId == placeHallId).ToList();

        return result;
    }
}
