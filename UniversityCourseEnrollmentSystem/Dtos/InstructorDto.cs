namespace UniversityCourseEnrollmentSystem.Dtos
{
    public class InstructorDto
    {
        public int Id { get; set; }                // Instructor ID
        public string FullName { get; set; }       // Ad Soyad (məs: Dr. John Smith)
        public string Email { get; set; }          // E-poçt ünvanı
        public string Office { get; set; }         // Ofis yeri (məs: Building B, Room 105)
        public DateTime HireDate { get; set; }     // İşə qəbul tarixi
        public int DepartmentId { get; set; }      // Hansı departamentə aiddir
    }
}
