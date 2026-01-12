using FoodWasteApp.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Dtos
{
    public record FoodItemDto :BaseDto
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

        public int ViewCount { get; set; }
        public int ReservationCount { get; set; }
    }
}
