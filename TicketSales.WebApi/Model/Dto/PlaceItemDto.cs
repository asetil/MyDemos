using Aware.Model.Dto;

namespace TicketSales.WebApi.Model.Dto
{
    public class PlaceItemDto : BaseItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long CityId { get; set; } //TODO will develop
        public string Address { get; set; }
        public long? ParentId { get; set; }
        public PlaceItemDto? Parent { get; set; }
    }
}
