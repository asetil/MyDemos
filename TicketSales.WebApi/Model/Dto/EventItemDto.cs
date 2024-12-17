using Aware.Model;

namespace TicketSales.WebApi.Model.Dto
{
    public class EventItemDto : BaseItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public long? OrganizerId { get; set; }
        public string Tags { get; set; } //Animasyon|Bilim Kurgu|Aile
        public EventOrganizerItemDto? Organizer { get; set; }
    }
}
