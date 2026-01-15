using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Dtos
{
    public record UserDto:BaseDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Address { get; set; }

        public DateTime RegisteredAt { get; set; }
        public DateTime? LastLoginAt { get; set; }

        public bool IsActive { get; set; }
        public bool EmailConfirmed { get; set; }

        public int TotalReservations { get; set; }
        public int CompletedReservations { get; set; }
        public int CancelledReservations { get; set; }
    }
}
