namespace UniversityCourseEnrollmentSystem.Models
{
    public class Student
    {
        public int Id { get; set; }  // Məs: 1, 2, 3...
        public string FullName { get; set; }  // Məs: "Aysel Məmmədova"
        public string Email { get; set; }  // Məs: "aysel.mammadova@university.edu"
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;  // Qeydiyyat tarixi

        // 🔹 Xarici açar (Foreign Key)
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // 🔹 Naviqasiya propertiləri (Relations)
        public ICollection<Enrollment> Enrollments { get; set; }  // Tələbənin qeydiyyatdan keçdiyi kurslar
    }
}
