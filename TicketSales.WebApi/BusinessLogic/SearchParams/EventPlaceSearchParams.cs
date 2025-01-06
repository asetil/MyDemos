using Aware.Search;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.SearchParams;

public class EventSessionSearchParams : SearchParams<EventSessionItemDto>
{
    public long? EventId { get; set; }
    public long? UserId { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }


    public override ISearchParams<EventSessionItemDto> Prepare()
    {
        if (EventId.HasValue)
            FilterBy(i => i.EventId == EventId.Value);

        if (UserId.HasValue)
            FilterBy(i => i.UserCreated == UserId.Value);

        if (DateStart.HasValue)
            FilterBy(i => i.StartTime >= DateStart.Value);

        if (DateEnd.HasValue)
            FilterBy(i => i.StartTime <= DateEnd.Value);

        SortBy(o => o.StartTime, descending: true);

        return this;
    }
}
