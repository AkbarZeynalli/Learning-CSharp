namespace ProfessionalFootballLeague_EFCORE_.Models
{
    internal class Team : BaseEntity
    {
        public string TeamName { get; set; }

        public int Played { get; set; }   // (O)
        public int Wins { get; set; }     //  (G)
        public int Draws { get; set; }    //  (H)
        public int Losses { get; set; }   //  (M)
        public int GoalsFor { get; set; } //  (AQ)
        public int GoalsAgainst { get; set; } //  (YQ)
        public ICollection<Player> Players { get; set; }

}
}
