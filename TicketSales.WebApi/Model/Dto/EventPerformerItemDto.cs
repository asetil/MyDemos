using Aware.Model.Dto;
using TicketSales.WebApi.Data.Entity;

namespace TicketSales.WebApi.Model.Dto
{
    public class EventPerformerItemDto : BaseItemDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public long EventId { get; set; }
        public EventEntity? Event { get; set; }
    }
}
