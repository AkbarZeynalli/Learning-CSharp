using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Dtos
{
    public record RestaurantDto : BaseDto
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
    }
}
