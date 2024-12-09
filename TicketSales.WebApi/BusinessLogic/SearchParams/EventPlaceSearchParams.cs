using Aware.Search;
using TicketSales.WebApi.Model.Dto;

namespace Worchart.Search
{
    public class EventPlaceSearchParams : SearchParams<EventPlaceItemDto>
    {
        public long? EventId { get; set; }
        public long? UserId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }


        public override ISearchParams<EventPlaceItemDto> Prepare()
        {
            if (EventId.HasValue)
                FilterBy(i => i.EventId == EventId.Value);

            if (UserId.HasValue)
                FilterBy(i => i.UserCreated == UserId.Value);

            if (DateStart.HasValue)
                FilterBy(i => i.StartDate >= DateStart.Value);

            if (DateEnd.HasValue)
                FilterBy(i => i.StartDate <= DateEnd.Value && i.EndDate <= DateEnd.Value);

            SortBy(o => o.StartDate, descending: true);

            return this;
        }
    }
}
