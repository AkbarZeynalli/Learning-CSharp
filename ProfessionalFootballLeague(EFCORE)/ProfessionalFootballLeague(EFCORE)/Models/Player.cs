namespace ProfessionalFootballLeague_EFCORE_.Models
{
    internal class Player : BaseEntity
    {
        public int ShirtNumber { get; set; }
        public string PlayerName { get; set; }
        public int GoalsScored { get; set; } // (Q)
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
