using Aware.Manager;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IEventService : IBaseManager<EventItemDto> { }

public class EventService(IServiceProvider serviceProvider) : BaseManager<EventEntity, EventItemDto>(serviceProvider), IEventService { }
