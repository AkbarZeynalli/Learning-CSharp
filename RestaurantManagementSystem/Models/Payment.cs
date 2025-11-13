namespace RestaurantManagementSystem.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string Method { get; set; } = "Cash"; // Cash, Card, Online
        public string Status { get; set; } = "Paid"; // Paid, Pending, Failed

        // Əlaqələr
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
