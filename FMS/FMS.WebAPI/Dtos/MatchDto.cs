namespace FMS.WebAPI.Dtos
{

    public record MatchDto : BaseDto
    {
        public DateTime MatchDate { get; set; }

        public string Stadium { get; set; }
        public int HomeClubId { get; set; }
        public int AwayClubId { get; set; }
        public int HomeClubGoals { get; set; }
        public int AwayClubGoals { get; set; }
    }
}
    
