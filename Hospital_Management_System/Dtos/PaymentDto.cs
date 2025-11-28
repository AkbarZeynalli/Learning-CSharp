namespace Hospital_Management_System.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
    }
}
