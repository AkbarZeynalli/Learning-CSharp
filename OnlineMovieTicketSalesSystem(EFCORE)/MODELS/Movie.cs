namespace OnlineMovieTicketSalesSystem_EFCORE_.MODELS
{
    internal class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get;  set; }
        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
