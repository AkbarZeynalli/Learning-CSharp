namespace OnlineMovieTicketSalesSystem_EFCORE_.MODELS
{
    internal class CinemaHall : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
