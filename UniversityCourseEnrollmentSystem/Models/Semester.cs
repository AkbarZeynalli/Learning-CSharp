namespace UniversityCourseEnrollmentSystem.Models
{
    public class Semester
    {
        public int Id { get; set; }

        public string Name { get; set; } // Məs: "Fall 2025" və ya "Spring 2026"
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Əlavə olaraq istəyə görə (optional)
        public bool IsActive { get; set; } = true;  // Hazırda aktiv semestrdirmi?

        // Naviqasiya property (1:N əlaqə)
        public ICollection<Course> Courses { get; set; }  // Bu semestrdə keçirilən kurslar
    }
}
