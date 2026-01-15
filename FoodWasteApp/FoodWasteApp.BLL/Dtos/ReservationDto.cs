using FoodWasteApp.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Dtos
{
    public record ReservationDto : BaseDto
    {
        public int UserId { get; set; }
        public int FoodItemId { get; set; }

        public int Quantity { get; set; }

        public DateTime PickupTime { get; set; }

        //public string? Notes { get; set; }
    }
}
