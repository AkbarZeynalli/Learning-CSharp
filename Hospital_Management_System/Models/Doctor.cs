namespace Hospital_Management_System.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<DoctorSpecialization> DoctorSpecializations { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
