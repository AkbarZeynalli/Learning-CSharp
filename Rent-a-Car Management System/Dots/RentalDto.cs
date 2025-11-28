namespace Rent_a_Car_Management_System.Dots
{
    public class RentalDto : BaseDto
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
