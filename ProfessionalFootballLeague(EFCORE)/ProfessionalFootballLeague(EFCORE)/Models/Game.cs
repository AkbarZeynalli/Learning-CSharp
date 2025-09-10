namespace ProfessionalFootballLeague_EFCORE_.Models
{
    internal class Game : BaseEntity
    {
        public int WeekNumber { get; set; }
        public int HomeTeamCode { get; set; }
        public int AwayTeamCode { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }

    }
}
