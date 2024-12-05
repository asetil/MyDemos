using Aware.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSales.WebApi.Data.Entity
{
    public class EventPlaceEntity : BaseEntity
    {
        [ForeignKey("Event")]
        public long EventId { get; set; }

        [ForeignKey("Place")]
        public long PlaceId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Ref
        public virtual EventEntity Event { get; set; }
        public virtual PlaceEntity Place { get; set; }
    }
}
