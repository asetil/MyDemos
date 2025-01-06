using Aware.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSales.WebApi.Data.Entity
{
    public class EventSessionEntity : BaseEntity
    {
        [ForeignKey("Event")]
        public long EventId { get; set; }

        [ForeignKey("PlaceHall")]
        public long PlaceHallId { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// ticket price or session price
        /// </summary>
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }

        //Ref
        public virtual EventEntity Event { get; set; }
        public virtual PlaceHallEntity PlaceHall { get; set; }
    }
}
