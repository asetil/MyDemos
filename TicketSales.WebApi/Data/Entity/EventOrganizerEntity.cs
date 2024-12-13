using Aware.Data.Entity;

namespace TicketSales.WebApi.Data.Entity
{
    public class EventOrganizerEntity : BaseEntity
    {
        public string Name { get; set; }

        //Ref
        public virtual ICollection<EventEntity> Events { get; set; }
    }
}
