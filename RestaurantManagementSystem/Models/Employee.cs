namespace RestaurantManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty; // Məs: "Waiter", "Chef"
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; } = DateTime.UtcNow;

        // Əlaqələr
        public ICollection<Order>? Orders { get; set; }  // İşçinin qəbul etdiyi sifarişlər
    }
}
