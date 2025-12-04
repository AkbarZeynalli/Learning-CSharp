namespace CMSApp.WebAPI.Dtos
{
    public record InstructorDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
    }
}
