using Aware.Manager;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IEventService : IBaseManager<EventEntity, EventItemDto>
{

}
