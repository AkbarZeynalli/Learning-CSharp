namespace UMSApp.WebAPI.Dtos
{
    public record TeacherDto:BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Fathername { get; set; }
        public DateTime? Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }

    }
}
