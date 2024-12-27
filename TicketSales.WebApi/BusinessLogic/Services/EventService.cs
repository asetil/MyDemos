using Aware.Manager;
using Microsoft.AspNetCore.SignalR;
using TicketSales.WebApi.BusinessLogic.Hubs;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IEventService : IBaseManager<EventItemDto> {
    Task PublishEvent(EventItemDto eventDto);
}

public class EventService(IServiceProvider serviceProvider, IHubContext<EventHub> hubContext) : BaseManager<EventEntity, EventItemDto>(serviceProvider), IEventService {
    public async Task PublishEvent(EventItemDto eventDto)
    {
        await hubContext.Clients.All.SendAsync("ReceiveEventUpdate", eventDto);
    }
}
