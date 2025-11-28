using Rent_a_Car_Management_System.Models;

namespace Rent_a_Car_Management_System.Dots
{
    public class CarDto:BaseDto
    {
        public string Plate { get; set; }

        public int BrandId { get; set; }

        public int CarModelId { get; set; }
    }
}
