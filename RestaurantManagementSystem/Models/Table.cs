namespace RestaurantManagementSystem.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }  // Məs: 1, 2, 3...
        public int Capacity { get; set; }     // Məs: 4 nəfərlik masa
        public bool IsAvailable { get; set; } = true;

        // Əlaqələr
        public ICollection<Order>? Orders { get; set; }
    }
}
