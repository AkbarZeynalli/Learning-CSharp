namespace AİRBNB.BLL.Dtos
{
    public record BookingDto : BaseDto
    {
        public int RoomId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
