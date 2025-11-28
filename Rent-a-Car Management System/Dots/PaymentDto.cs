namespace Rent_a_Car_Management_System.Dots
{
    public class PaymentDto : BaseDto
    {
        public int RentalId { get; set; }
        public decimal Amount { get; set; }
    }
}
