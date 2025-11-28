namespace Rent_a_Car_Management_System.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}
