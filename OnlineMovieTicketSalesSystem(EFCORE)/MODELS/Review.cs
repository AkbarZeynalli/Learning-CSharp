namespace OnlineMovieTicketSalesSystem_EFCORE_.MODELS
{
    internal class Review : BaseEntity
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int MovieID { get; set; }
        public Movie Movie { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
