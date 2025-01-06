using Aware.Model.Dto;
using TicketSales.WebApi.BusinessLogic.Util;

namespace TicketSales.WebApi.Model.Dto;

public class PlaceHallSeatItemDto : BaseItemDto
{
    public string Name { get; set; } //G14
    public int Row { get; set; } //G as line 7
    public int Column { get; set; } //seat number 14
    public SeatType Type { get; set; }
    public SeatBlock Block { get; set; } = SeatBlock.NA;
    public long PlaceHallId { get; set; }
    public PlaceHallItemDto? PlaceHall { get; set; }
}
