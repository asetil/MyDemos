using Aware.Model;
using Aware.Util.Web;
using Microsoft.AspNetCore.Mvc;
using TicketSales.WebApi.BusinessLogic.Services;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.Controllers;

public class EventTicketController(IEventTicketService ticketService) : AwareAuthorizedController<EventTicketItemDto>(ticketService)
{
    [HttpPost("buy-ticket")]
    public OperationResult<EventTicketItemDto> BuyTicket([FromBody] EventTicketItemDto ticketItem)
    {
        return ticketService.BuyTicket(ticketItem);
    }
}
