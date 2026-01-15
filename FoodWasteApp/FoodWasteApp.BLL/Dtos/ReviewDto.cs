using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Dtos
{
    public record ReviewDto : BaseDto
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }

        public int Rating { get; set; }
        public string? Comment { get; set; }

    }
}
