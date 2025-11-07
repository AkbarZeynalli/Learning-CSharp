namespace UniversityCourseEnrollmentSystem.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }               // Student ID
        public string FullName { get; set; }      // Ad Soyad
        public string Email { get; set; }         // Email ünvanı
        public DateTime EnrollmentDate { get; set; } // Qeydiyyat tarixi
        public int DepartmentId { get; set; }     // Hansı departmentə aid olduğunu göstərir
    }
}
