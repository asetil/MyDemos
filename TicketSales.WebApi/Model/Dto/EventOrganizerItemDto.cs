using Aware.Model.Dto;

namespace TicketSales.WebApi.Model.Dto
{
    public class EventOrganizerItemDto : BaseItemDto
    {
        public string Name { get; set; }
        public int EventCount { get; set; }
    }
}
