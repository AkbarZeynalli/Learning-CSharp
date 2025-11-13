namespace RestaurantManagementSystem.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty; // Cash, Card, etc.
        public DateTime PaymentDate { get; set; }
    }
}
