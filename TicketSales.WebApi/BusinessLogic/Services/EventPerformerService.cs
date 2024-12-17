using Aware.Manager;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IEventPerformerService : IBaseManager<EventPerformerItemDto> { }

public class EventPerformerService(IServiceProvider serviceProvider) : BaseManager<EventPerformerEntity, EventPerformerItemDto>(serviceProvider), IEventPerformerService { }
