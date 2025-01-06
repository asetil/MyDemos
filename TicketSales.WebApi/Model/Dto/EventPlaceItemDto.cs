using Aware.Model.Dto;

namespace TicketSales.WebApi.Model.Dto;

public class EventSessionItemDto : BaseItemDto
{
    public long EventId { get; set; }
    public long PlaceHallId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime StartTime { get; set; }
    public EventItemDto? Event { get; set; }
    public PlaceHallItemDto? PlaceHall { get; set; }
}
