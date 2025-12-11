namespace FMS.WebAPI.Dtos
{
    public record PlayerDto : BaseDto
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int ShirtNumber { get; set; }
        public int ClubId { get; set; }
        public string Position { get; set; }
    }
}
