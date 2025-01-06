using Aware.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using TicketSales.WebApi.BusinessLogic.Util;

namespace TicketSales.WebApi.Data.Entity
{
    public class PlaceHallSeatEntity : BaseEntity
    {
        public string Name { get; set; } //G14
        public int Row { get; set; } //G as line 7
        public int Column { get; set; } //seat number 14
        public SeatType Type { get; set; }
        public SeatBlock Block { get; set; } = SeatBlock.NA;

        [ForeignKey("PlaceHall")]
        public long PlaceHallId { get; set; }

        //Ref
        public virtual PlaceHallEntity PlaceHall { get; set; }
    }
}
