namespace RestaurantManagementSystem.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }   // Məs: "Chicken", "Tomato Sauce"
        public int Quantity { get; set; }
        public string Unit { get; set; } = "kg";          // Məs: kg, litre, piece
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
