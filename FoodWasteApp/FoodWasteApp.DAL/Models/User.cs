namespace FoodWasteApp.DAL.Models
{
    public class User :BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Address { get; set; }

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLoginAt { get; set; }

        public bool IsActive { get; set; } = true;

        public bool EmailConfirmed { get; set; } = false;

        public int TotalReservations { get; set; } = 0;

        public int CompletedReservations { get; set; } = 0;

        public int CancelledReservations { get; set; } = 0;

        // Navigation Properties
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
