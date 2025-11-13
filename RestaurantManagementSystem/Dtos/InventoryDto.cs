namespace RestaurantManagementSystem.Dtos
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public string ItemName { get; set; } 
        public int Quantity { get; set; }
        public string Unit { get; set; } = string.Empty; // e.g., kg, pcs, ltr
    }
}
