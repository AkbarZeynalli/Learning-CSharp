namespace Hospital_Management_System.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DoctorSpecialization> DoctorSpecializations { get; set; }
    }
}
