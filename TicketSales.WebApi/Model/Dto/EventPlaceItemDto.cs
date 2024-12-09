using Aware.Model;
namespace TicketSales.WebApi.Model.Dto
{
    public class EventPlaceItemDto : BaseItemDto
    {
        public long EventId { get; set; }
        public long PlaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual EventItemDto Event { get; set; }
        public virtual PlaceItemDto Place { get; set; }
    }
}
