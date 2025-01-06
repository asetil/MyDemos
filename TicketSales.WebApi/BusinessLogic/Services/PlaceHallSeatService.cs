using Aware.Manager;
using Aware.Util.Enum;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IPlaceHallSeatService : IBaseManager<PlaceHallSeatItemDto> { }

public class PlaceHallSeatService(IServiceProvider serviceProvider) : BaseManager<PlaceHallSeatEntity, PlaceHallSeatItemDto>(serviceProvider), IPlaceHallSeatService
{
    protected override ManagerCacheMode CacheMode => ManagerCacheMode.UseCache;
}
