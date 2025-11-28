namespace Hospital_Management_System.Models
{
    public class DoctorSpecialization
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }

}
