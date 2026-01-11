using FoodWasteApp.DAL.Models.Enums;

namespace FoodWasteApp.DAL.Models
{
    public class FoodItem: BaseEntity
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public FoodCategory Category { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public string? AllergenInfo { get; set; }
        public int ViewCount { get; set; } = 0;
        public int ReservationCount { get; set; } = 0;
        public virtual Restaurant Restaurant { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
