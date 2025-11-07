namespace UniversityCourseEnrollmentSystem.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        // Xarici açarlar (Foreign Keys)
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Pending;
        public decimal? Grade { get; set; }  // Məs: 85.5 və ya null (qiymət hələ verilməyibsə)

        // Naviqasiya propertiləri (Relations)
        public Student Student { get; set; }
        public Course Course { get; set; }
    }

    public enum EnrollmentStatus
    {
        Pending,    // Tələbə müraciət edib, hələ təsdiqlənməyib
        Approved,   // Qəbul olunub
        Rejected,   // Rədd edilib
        Completed   // Kursu bitirib
    }
}
