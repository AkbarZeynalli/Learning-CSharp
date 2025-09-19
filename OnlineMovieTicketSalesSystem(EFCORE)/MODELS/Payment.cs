namespace OnlineMovieTicketSalesSystem_EFCORE_.MODELS
{
    internal class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethodType PaymentMethodType { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
