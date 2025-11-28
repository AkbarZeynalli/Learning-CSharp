namespace Hospital_Management_System.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public decimal Amount { get; set; }
        public DateTime PaidAt { get; set; }
    }
}
