using Aware.Data.Entity;

namespace TicketSales.WebApi.Data.Entity
{
    public class EventEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string Tags { get; set; } //Animasyon|Bilim Kurgu|Aile
        public int Type { get; set; } //EventType enum
    }
}
