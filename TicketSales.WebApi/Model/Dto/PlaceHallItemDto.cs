using Aware.Model.Dto;

namespace TicketSales.WebApi.Model.Dto;

public class PlaceHallItemDto : BaseItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long PlaceId { get; set; }
    public PlaceItemDto? Place { get; set; }
}
