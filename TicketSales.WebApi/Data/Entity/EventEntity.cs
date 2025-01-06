using Aware.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSales.WebApi.Data.Entity
{
    public class EventEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("Organizer")]
        public long? OrganizerId { get; set; }
        public string Tags { get; set; } //Animation|Science & Fiction|Family
        public int Type { get; set; } //EventType enum

        //Ref
        public virtual EventOrganizerEntity Organizer { get; set; }
    }
}
