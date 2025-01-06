using Aware.Util.Web;
using TicketSales.WebApi.BusinessLogic.Services;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.Controllers;

public class PlaceHallSeatController(IPlaceHallSeatService seatService) : AwareAuthorizedController<PlaceHallSeatItemDto>(seatService)
{

}
