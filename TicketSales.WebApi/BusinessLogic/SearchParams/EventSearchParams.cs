using Aware.Search;
using TicketSales.WebApi.Model.Dto;

namespace TicketSales.WebApi.BusinessLogic.SearchParams;

/// <summary>
/// You can create your own search class and apply custom filter and sortings
/// </summary>
public class EventSearchParams : SearchParams<EventItemDto>
{
    public long? OrganizerId { get; set; }

    public override ISearchParams<EventItemDto> Prepare()
    {
        if (OrganizerId.HasValue)
            FilterBy(i => i.OrganizerId == OrganizerId.Value);

        //If you want to apply sorting only if not any present then check _sortlist first
        //Without this check the sorting will be added as last sort statement
        if (_sortList == null || _sortList.Count == 0)
            SortBy(o => o.DateCreated, descending: true);

        return this;
    }
}
