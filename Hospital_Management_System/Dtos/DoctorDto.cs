namespace Hospital_Management_System.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }

        public int DepartmentId { get; set; }

    }
}
