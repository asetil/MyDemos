using Microsoft.AspNetCore.SignalR;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Hubs;

public class EventHub : Hub
{
    public async Task SendEventUpdate(EventItemDto eventDto)
    {
        await Clients.All.SendAsync("ReceiveEventUpdate",eventDto);
    }
}
