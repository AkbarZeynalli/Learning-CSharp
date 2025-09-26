// Person.cs
namespace CourseManagementSoftware.MODELS
{
    internal class Person : BaseEntity
    {
        public Person() { } // EF Core üçün parameterless ctor

        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        // optional fields
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        // Əgər doğum tarixi saxlamaq istəsən:
        // public DateOnly? BirthDate { get; set; }
    }
}
