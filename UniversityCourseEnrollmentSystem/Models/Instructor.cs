namespace UniversityCourseEnrollmentSystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }  // Məs: 1, 2, 3...

        public string FullName { get; set; }  // Məs: "Dr. John Smith"
        public string Email { get; set; }
        public string Office { get; set; }  // Məs: "Building B, Room 105"
        public DateTime HireDate { get; set; } = DateTime.UtcNow;  // İşə qəbul tarixi

        // 🔹 Xarici açar (Foreign Key)
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // 🔹 Naviqasiya propertiləri
        public ICollection<Course> Courses { get; set; }  // Müəllimin tədris etdiyi kurslar
    }
}
