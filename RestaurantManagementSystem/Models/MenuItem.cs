namespace RestaurantManagementSystem.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;   // Məs: "Pizza Margherita"
        public string Category { get; set; } = string.Empty;  // Məs: "Food", "Drink"
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public bool IsAvailable { get; set; } = true;

        // Əlaqələr
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
