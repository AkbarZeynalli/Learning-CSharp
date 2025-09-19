namespace OnlineMovieTicketSalesSystem_EFCORE_.MODELS
{
    internal class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
