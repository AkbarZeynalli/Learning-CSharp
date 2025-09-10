using ProfessionalFootballLeague_EFCORE_.DATA;
using ProfessionalFootballLeague_EFCORE_.Models;

namespace ProfessionalFootballLeague_EFCORE_.Services
{
    internal class OperationService
    {
        private AppDbContext appContext;
        public OperationService()
        {
            appContext = new AppDbContext();
        }
        public void AddTeam()
        {
            Team team = new Team();

            Console.Write("Komanda adı: ");
            team.TeamName = Console.ReadLine();
            Console.Write("Oynadığı oyun sayı: ");
            team.Played = Convert.ToInt32(Console.ReadLine());
            Console.Write("Qalibiyyət sayı: ");
            team.Wins = Convert.ToInt32(Console.ReadLine());
            Console.Write("Meydan oxuma sayı: ");
            team.Draws = Convert.ToInt32(Console.ReadLine());
            Console.Write("Məğlubiyyət sayı: ");
            team.Losses = Convert.ToInt32(Console.ReadLine());
            Console.Write("Atılan qol sayı: ");
            team.GoalsFor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Buraxılan qol sayı: ");
            team.GoalsAgainst = Convert.ToInt32(Console.ReadLine());
            appContext.Teams.Add(team);
            appContext.SaveChanges();
        }
        public void AddPlayer()
        {
            Player player = new Player();
            var teams = appContext.Teams.ToList();
            if (teams.Count == 0)
            {
                Console.WriteLine("Əvvəlcə komanda əlavə edin.");
                return;
            }
            foreach (var team in teams)
            {
                Console.WriteLine($"ID: {team.Id}, Komanda adı: {team.TeamName}");
            }
            Console.Write("Futbolçunun komandasının ID-sini daxil edin: ");
            int teamId = Convert.ToInt32(Console.ReadLine());
            player.TeamId = teamId;
            Console.Write("Futbolçunun  ShirtNumber: ");
            player.ShirtNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Futbolçunun adı: ");
            player.PlayerName = Console.ReadLine();
            Console.Write("Atılan qol sayı: ");
            player.GoalsScored = Convert.ToInt32(Console.ReadLine());
            appContext.Players.Add(player);
            appContext.SaveChanges();
        }
        public void AddGame()
        {
            Game game = new Game();
            var teams = appContext.Teams.ToList();
            if (teams.Count < 2)
            {
                Console.WriteLine("Əvvəlcə ən azı iki komanda əlavə edin.");
                return;
            }
            foreach (var team in teams)
            {
                Console.WriteLine($"ID: {team.Id}, Komanda adı: {team.TeamName}");
            }
            Console.Write("Ev sahibi komandanın ID-sini daxil edin: ");
            int homeTeamId = Convert.ToInt32(Console.ReadLine());
            game.HomeTeamCode = homeTeamId;
            Console.Write("Qonaq komandanın ID-sini daxil edin: ");
            int awayTeamId = Convert.ToInt32(Console.ReadLine());
            game.AwayTeamCode = awayTeamId;
            Console.Write("Həftə nömrəsi: ");
            game.WeekNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ev sahibi komandanın vurduğu qol sayı: ");
            game.HomeGoals = Convert.ToInt32(Console.ReadLine());
            Console.Write("Qonaq komandanın vurduğu qol sayı: ");
            game.AwayGoals = Convert.ToInt32(Console.ReadLine());
            appContext.Game.Add(game);
            appContext.SaveChanges();
        }
        public void GetAllTeams()
        {
            var teams = appContext.Teams.ToList();
            Console.WriteLine("Komandalar:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("ID |Komanda adı |Oynadığı oyun sayı |Qalibiyyət sayı |Meydan oxuma sayı |Məğlubiyyət sayı |Atılan qol sayı |Buraxılan qol sayı");
            Console.WriteLine();
            foreach (var team in teams)
            {
                Console.WriteLine($"{team.Id},  {team.TeamName},   {team.Played},                 {team.Wins},              {team.Draws},                 {team.Losses},                  {team.GoalsFor},              {team.GoalsAgainst}");
            }
        }
        public void GetAllPlayers(int teamId)
        {

            var players = appContext.Players.Where(x => x.TeamId == teamId).ToList();


            Console.WriteLine("Futbolçular:");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("ID | Komanda ID | ShirtNumber | Futbolçunun adı | Atılan qol sayı");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.Id},   {player.TeamId},            {player.ShirtNumber},           {player.PlayerName},           {player.GoalsScored}");
            }
        }
        public void GetPlayerGoals(int playerId)
        {
            var player = appContext.Players.FirstOrDefault(x => x.Id == playerId);
            if (player != null)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Futbolçu: {player.PlayerName}, Atılan qol sayı: {player.GoalsScored}");
            }
            else
            {
                Console.WriteLine("Belə bir futbolçu tapılmadı.");
            }
        }
        public void GetTopScoringAndConcedingTeams()
        {
            var topScoringTeam = appContext.Teams.OrderByDescending(t => t.GoalsFor).FirstOrDefault();
            var topConcedingTeam = appContext.Teams.OrderByDescending(t => t.GoalsAgainst).FirstOrDefault();
            if (topScoringTeam != null)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Ən çox qol atan komanda: {topScoringTeam.TeamName} - Atılan qol sayı: {topScoringTeam.GoalsFor}");
            }
            else
            {
                Console.WriteLine("Komanda məlumatları mövcud deyil.");
            }
            if (topConcedingTeam != null)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Ən çox qol yeyən komanda: {topConcedingTeam.TeamName} - Buraxılan qol sayı: {topConcedingTeam.GoalsAgainst}");
            }
            else
            {
                Console.WriteLine("Komanda məlumatları mövcud deyil.");
            }
        }
        public void GetTopScoringPlayer()
        {
            var topScoringPlayer = appContext.Players.OrderByDescending(p => p.GoalsScored).FirstOrDefault();
            if (topScoringPlayer != null)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Ən çox qol atan futbolçu: {topScoringPlayer.PlayerName} - Atılan qol sayı: {topScoringPlayer.GoalsScored}");
            }
            else
            {
                Console.WriteLine("Futbolçu məlumatları mövcud deyil.");
            }
        }
    }
}
