using FoodWasteApp.DAL.Models.Enums;

namespace FoodWasteApp.DAL.Models
{
    public class Reservation : BaseEntity
    {
        public int UserId { get; set; }
        public int FoodItemId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ReservationTime { get; set; }
        public DateTime PickupTime { get; set; }
        public DateTime? ActualPickupTime { get; set; }
        public ReservationStatus Status { get; set; }
        public string? CancellationReason { get; set; }
        public string? Notes { get; set; }
        public virtual User User { get; set; }
        public virtual FoodItem FoodItem { get; set; }

    }
}
