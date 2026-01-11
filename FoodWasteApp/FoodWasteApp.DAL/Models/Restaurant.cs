using FoodWasteApp.DAL.Models;

namespace FoodWasteApp.DAL.Models
{
    public class Restaurant : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; }
        public decimal AverageRating { get; set; }
        public int TotalReviews { get; set; }
        public virtual ICollection<FoodItem> FoodItems { get; set; } = new List<FoodItem>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
