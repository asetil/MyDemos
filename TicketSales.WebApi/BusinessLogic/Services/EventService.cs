using Aware.Manager;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public class EventService : BaseManager<EventEntity, EventItemDto>, IEventService
{
    public EventService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
