namespace UniversityCourseEnrollmentSystem.Dtos
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledAt { get; set; }
        public string Status { get; set; } // Enum adını string kimi göndərmək üçün
        public decimal? Grade { get; set; }
    }
}
