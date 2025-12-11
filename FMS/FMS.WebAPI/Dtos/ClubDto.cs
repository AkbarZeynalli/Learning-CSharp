namespace FMS.WebAPI.Dtos
{
    public record ClubDto : BaseDto
    {
        public string Name { get; set; }
        public int LeagueId { get; set; }
        public DateTime FoundedYear { get; set; } 
    }
}
