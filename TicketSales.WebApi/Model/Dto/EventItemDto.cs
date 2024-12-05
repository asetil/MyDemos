using Aware.Model;

namespace TicketSales.WebApi.Model.Dto
{
    public class EventItemDto : BaseItemDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
    }
}
