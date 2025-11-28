namespace Rent_a_Car_Management_System.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CarModel> Models { get; set; }
        public List<Car> Cars { get; set; }
    }
    



}
