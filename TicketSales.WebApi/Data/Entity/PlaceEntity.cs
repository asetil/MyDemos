using Aware.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSales.WebApi.Data.Entity
{
    public class PlaceEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long CityId { get; set; } //TODO will develop
        public string Address { get; set; }

        [ForeignKey("Parent")]
        public long? ParentId { get; set; }

        //Ref
        public virtual PlaceEntity Parent { get; set; }
    }
}
