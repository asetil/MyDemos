using Aware.Manager;
using Aware.Util;
using Aware.Util.Constants;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IEventOrganizerService : IBaseManager<EventOrganizerItemDto>
{
    List<EventOrganizerItemDto> GetTopList();
}

public class EventOrganizerService(IServiceProvider serviceProvider) : BaseManager<EventOrganizerEntity, EventOrganizerItemDto>(serviceProvider), IEventOrganizerService
{
    public List<EventOrganizerItemDto> GetTopList()
    {
        var result = Cacher.GetData<List<EventOrganizerItemDto>>(Util.TickesSalesCacheKeys.OrganizerTopList);
        if (result == null)
        {
            using var unitOfWork = GetUnitOfWork();
            var searchResult = unitOfWork.GetQuery<EventOrganizerEntity>().Select(o => new
            {
                Organizer = o,
                EventCount = o.Events.Count()
            }).OrderByDescending(x => x.EventCount).Take(10).ToList();

            if (searchResult != null && searchResult.Count > 0)
            {
                result = searchResult.Select(s => MapTo(s.Organizer)).ToList();
                result.ForEach(f =>
                {
                    f.EventCount = searchResult.FirstOrDefault(a => a.Organizer.Id == f.Id)?.EventCount ?? 0;
                });
            }

            Cacher.AddToCache(Util.TickesSalesCacheKeys.OrganizerTopList, result, CommonConstants.HourlyCacheTime);
        }

        return result ?? new List<EventOrganizerItemDto>();
    }
}
