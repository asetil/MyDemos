using Aware.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSales.WebApi.Data.Entity
{
    public class EventPerformerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }

        [ForeignKey("Event")]
        public long EventId { get; set; }

        //Ref
        public virtual EventEntity Event { get; set; }
    }
}
