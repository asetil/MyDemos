using Aware.Manager;
using Aware.Model;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IEventTicketService : IBaseManager<EventTicketItemDto>
{
    OperationResult<EventTicketItemDto> BuyTicket(EventTicketItemDto ticketItem);
}

public class EventTicketService(IServiceProvider serviceProvider, IEventSessionService eventSessionService, IPlaceHallSeatService seatService) : BaseManager<EventTicketEntity, EventTicketItemDto>(serviceProvider), IEventTicketService
{
    public OperationResult<EventTicketItemDto> BuyTicket(EventTicketItemDto ticketItem)
    {
        var eventSessionItem = eventSessionService.WithSearchParams(navigationFields: "Event").First(p => p.Id == ticketItem.EventSessionId);
        if (eventSessionItem == null || eventSessionItem.Event == null || eventSessionItem.Event.Status != Aware.Util.Enum.StatusType.Active)
        {
            return Failed<EventTicketItemDto>("EVENT_IS_NOT_SUITABLE_TO_BUY_TICKET");
        }

        var seat = seatService.First(p => p.Id == ticketItem.HallSeatId);
        if (seat == null || seat.Status != Aware.Util.Enum.StatusType.Active)
        {
            return Failed<EventTicketItemDto>("SEAT_IS_NOT_SUITABLE_TO_BUY_TICKET");
        }

        var soldTicket = First(p => p.EventSessionId == ticketItem.EventSessionId && p.HallSeatId == ticketItem.HallSeatId);
        if (soldTicket != null)
        {
            return Failed<EventTicketItemDto>("TICKET_ALREADY_SOLD");
        }

        return Save(ticketItem);
    }
}
