using Aware.Data.Entity;
using Aware.Util.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSales.WebApi.Data.Entity
{
    public class EventTicketEntity : BaseEntity
    {
        [ForeignKey("EventSession")]
        public long EventSessionId { get; set; }

        [ForeignKey("HallSeat")]
        public long HallSeatId { get; set; }

        [ForeignKey("User")]
        public long? UserId { get; set; }

        /// <summary>
        /// Which gender occupied
        /// </summary>
        public GenderType Gender { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseTime { get; set; }

        //Ref
        public virtual EventSessionEntity EventSession { get; set; }
        public virtual PlaceHallSeatEntity HallSeat { get; set; }
        public virtual UserEntity? User { get; set; }
    }
}
