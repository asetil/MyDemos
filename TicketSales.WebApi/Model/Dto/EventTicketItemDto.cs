using Aware.Data.Entity;
using Aware.Model.Dto;
using Aware.Util.Enum;
using TicketSales.WebApi.Data.Entity;

namespace TicketSales.WebApi.Model.Dto
{
    public class EventTicketItemDto : BaseItemDto
    {
        public long EventSessionId { get; set; }
        public long HallSeatId { get; set; }
        public long? UserId { get; set; }

        /// <summary>
        /// Which gender occupied the seat
        /// </summary>
        public GenderType Gender { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseTime { get; set; }

        public EventSessionEntity? EventSession { get; set; }
        public PlaceHallSeatEntity? HallSeat { get; set; }
        public UserEntity? User { get; set; }
    }
}
