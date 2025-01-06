using Aware.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSales.WebApi.Data.Entity
{
    public class PlaceHallEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("Place")]
        public long PlaceId { get; set; }

        //Ref
        public virtual PlaceEntity Place { get; set; }
    }
}
