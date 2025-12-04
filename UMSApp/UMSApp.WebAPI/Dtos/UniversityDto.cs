namespace UMSApp.WebAPI.Dtos
{
    public record UniversityDto : BaseDto
    {
        public string Name { get; init; }
        public string Address { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
    }
}
