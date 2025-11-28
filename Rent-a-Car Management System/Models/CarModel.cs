namespace Rent_a_Car_Management_System.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Car> Cars { get; set; }
    }
}
