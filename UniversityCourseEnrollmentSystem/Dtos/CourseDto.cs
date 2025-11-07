namespace UniversityCourseEnrollmentSystem.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }                // Kursun unikal ID-si
        public string Title { get; set; }          // Kursun adı
        public string Code { get; set; }           // Məsələn: "CS101"
        public int Credits { get; set; }           // Kredit sayı
        public string? Description { get; set; }   // Qısa izah

        // Xarici açarlar (foreign keys)
        public int InstructorId { get; set; }     // Müəllimin ID-si
        public int DepartmentId { get; set; }     // Fakültənin ID-si
        public int SemesterId { get; set; }       // Semestrin ID-si
    }
}
