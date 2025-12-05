namespace FMS.WebAPI.Dtos
{
    public record MatchDto :BaseDto
    {
        public DateTime MatchDate { get; set; }
        public int HomeClubId { get; set; }
        public string HomeClubName { get; set; }
        public int AwayClubId { get; set; }
        public string AwayClubName { get; set; }
        public int HomeClubGoals { get; set; }
        public int AwayClubGoals { get; set; }
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
    }
}
