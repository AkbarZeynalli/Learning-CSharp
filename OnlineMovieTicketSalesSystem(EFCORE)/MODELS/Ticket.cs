namespace OnlineMovieTicketSalesSystem_EFCORE_.MODELS
{
    internal class Ticket : BaseEntity
    {
        public string SeatNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ShowtimeId { get; set; }
        public Showtime Showtime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
