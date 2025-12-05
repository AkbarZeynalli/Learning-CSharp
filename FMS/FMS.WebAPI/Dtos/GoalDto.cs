namespace FMS.WebAPI.Dtos
{
    public record GoalDto : BaseDto
    {
        public int PlayerId { get; set; }
        public int MatchId { get; set; }
        public int Minute { get; set; }
    }
}
