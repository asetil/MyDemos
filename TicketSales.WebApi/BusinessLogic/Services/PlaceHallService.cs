using Aware.Manager;
using Aware.Util.Enum;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IPlaceHallService : IBaseManager<PlaceHallItemDto> { }

public class PlaceHallService(IServiceProvider serviceProvider) : BaseManager<PlaceHallEntity, PlaceHallItemDto>(serviceProvider), IPlaceHallService
{
    /// <summary>
    /// Place hall data will be cached and will be refreshed on save and delete operations.
    /// </summary>
    protected override ManagerCacheMode CacheMode => ManagerCacheMode.UseCache;
}
