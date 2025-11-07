namespace UniversityCourseEnrollmentSystem.Models
{
    public class Course
    {
        public int Id { get; set; }   // Sadə ID (1, 2, 3...)

        public string Title { get; set; }
        public string Code { get; set; }  // Məs: "CS101"
        public int Credits { get; set; }
        public string Description { get; set; }

        // Relationships
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
