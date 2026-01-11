namespace FoodWasteApp.DAL.Models
{
    public class Review : BaseEntity
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

        public bool IsVerified { get; set; }

        public int HelpfulCount { get; set; }

        public virtual User User { get; set; }
        public virtual Restaurant Restaurant { get; set; } = null!;
    }
}
