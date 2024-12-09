using Aware.Manager;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IEventPlaceService : IBaseManager<EventPlaceItemDto> { }

public class EventPlaceService(IServiceProvider serviceProvider) : BaseManager<EventPlaceEntity, EventPlaceItemDto>(serviceProvider), IEventPlaceService
{
}
