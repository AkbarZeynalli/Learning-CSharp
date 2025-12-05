namespace FMS.WebAPI.Dtos
{
    public record PlayerDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ClubId { get; set; }
        public string ClubName { get; set; }
        public string Position { get; set; }
    }
}
