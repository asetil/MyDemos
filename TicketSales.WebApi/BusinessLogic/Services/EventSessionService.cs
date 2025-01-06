using Aware.Manager;
using TicketSales.WebApi.Data.Entity;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.Services;

public interface IEventSessionService : IBaseManager<EventSessionItemDto> {
    List<PlaceItemDto> GetEventPlaces(long eventId);
}

public class EventSessionService(IServiceProvider serviceProvider) : BaseManager<EventSessionEntity, EventSessionItemDto>(serviceProvider), IEventSessionService
{
    public List<PlaceItemDto> GetEventPlaces(long eventId)
    {
        using (var unitOfWork = GetUnitOfWork())
        {
            var query = from eventSession in unitOfWork.GetQuery<EventSessionEntity>()
                        join placeHall in unitOfWork.GetQuery<PlaceHallEntity>() on eventSession.PlaceHallId equals placeHall.Id
                        join place in unitOfWork.GetQuery<PlaceEntity>() on placeHall.PlaceId equals place.Id
                        where eventSession.EventId == eventId
                        select new PlaceItemDto()
                        {
                            Id = place.Id,
                            Name = place.Name,
                            Address = place.Address,
                            CityId = place.CityId,
                            Status = place.Status,
                            Description = place.Description
                        };

            var eventPlaceList = query.Distinct().ToList();
            return eventPlaceList;
        }
    }
}
