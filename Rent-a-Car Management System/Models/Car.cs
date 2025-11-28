namespace Rent_a_Car_Management_System.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Plate { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
    }



}
