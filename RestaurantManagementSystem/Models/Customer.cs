namespace RestaurantManagementSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        // Əlaqələr
        public ICollection<Order>? Orders { get; set; }  // Müştərinin sifarişləri
    }
}
