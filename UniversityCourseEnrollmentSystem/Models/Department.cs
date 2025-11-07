namespace UniversityCourseEnrollmentSystem.Models
{
    public class Department
    {
        public int Id { get; set; }  // Məs: 1, 2, 3...
        public string Name { get; set; }  // Məs: "Computer Engineering"
        public string Office { get; set; }  // Məs: "Building A, Room 203"
        public string Phone { get; set; }   // əlavə məlumat üçün (optional)

        // 🔹 Əlaqələr (Relationships)
        public ICollection<Course> Courses { get; set; }  // Departamentdəki dərslər
        public ICollection<Instructor> Instructors { get; set; }  // Bu departamentdə işləyən müəllimlər
    }
}
