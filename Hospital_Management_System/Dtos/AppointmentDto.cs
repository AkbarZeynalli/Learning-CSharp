namespace Hospital_Management_System.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
