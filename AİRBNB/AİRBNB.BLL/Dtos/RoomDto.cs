namespace AİRBNB.BLL.Dtos
{
    public record RoomDto : BaseDto
    {
        public string Title { get; set; }
        public decimal PricePerNight { get; set; }
        public int MaxGuests { get; set; }

        public int LocationId { get; set; }
    }
}
