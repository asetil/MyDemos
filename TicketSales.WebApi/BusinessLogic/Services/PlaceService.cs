using Aware.Manager;
using Aware.Util.Enum;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IPlaceService : IBaseManager<PlaceItemDto> { }

public class PlaceService(IServiceProvider serviceProvider) : BaseManager<PlaceEntity, PlaceItemDto>(serviceProvider), IPlaceService
{
    /// <summary>
    /// Place data will be cached and will be refreshed on save and delete operations.
    /// </summary>
    protected override ManagerCacheMode CacheMode => ManagerCacheMode.UseCache;

    /// <summary>
    /// A nice place to add some custom logic after save
    /// </summary>
    /// <param name="model"></param>
    protected override void OnAfterSave(PlaceItemDto model)
    {
        if (model != null && model.Id == 0)
        {
            //Logger is comes from BaseManager as ready.
            Logger.Warn("PLACE", "A new place saved : {0}", sendMail: false, model.Name);
        }

        base.OnAfterSave(model);
    }
}
