using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalFootballLeague
{
    internal class OperationManagamentSistem
    {
        Store store = new Store();

        public void AddLeauge()
        {
            Leauge leauge = new Leauge();
            Console.Write("Leauge Id: ");
            leauge.LeaugeId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Leauge Name: ");
            leauge.LeaugeName = Console.ReadLine();
            leauge.LeaugeId= store.LeaugeList.Count + 1; 
            store.LeaugeList.Add(leauge);
        }

        public void AddTeam()
        {
            foreach(var item in store.LeaugeList)
            {
                Console.WriteLine($"Id: {item.LeaugeId}, Name: {item.LeaugeName}");
            }
            Console.Write("Select Leauge Id to add team: ");
            int leaugeId = Convert.ToInt32(Console.ReadLine());
            Team team = new Team();
            Console.Write("Team Id: ");
            team.TeamId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Team Name: ");
            team.TeamName = Console.ReadLine();
            store.TeamList.Add(team);
        }

        public void AddPlayer()
        {

            foreach (var item in store.TeamList)
            {
                Console.WriteLine($"Id: {item.TeamId}, Name: {item.TeamName}");
            }
            Console.Write("Select Team Id to add player: ");
            int teamId = Convert.ToInt32(Console.ReadLine());
            Player player = new Player();
            Console.Write("Player Id: ");
            player.PlayerId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Player Name: ");
            player.PlayerName = Console.ReadLine();
            player.PlayerId = store.PlayerList.Count + 1;
            store.PlayerList.Add(player);
        }

        public void ShowLeagues()
        {
            if (store.LeaugeList.Count == 0)
            {
                Console.WriteLine("No leagues available.");
                return;
            }

            Console.WriteLine("\nLeagues:");
            for (int i = 0; i < store.LeaugeList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {store.LeaugeList[i]}");
            }
        }

        public void ShowTeams()
        {
            if (store.TeamList.Count == 0)
            {
                Console.WriteLine("No teams available.");
                return;
            }

            Console.WriteLine("\nTeams:");
            for (int i = 0; i < store.TeamList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {store.TeamList[i]}");
            }
        }

        public void ShowPlayers()
        {
            if (store.PlayerList.Count == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }

            Console.WriteLine("\nPlayers:");
            for (int i = 0; i < store.PlayerList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {store.PlayerList[i]}");
            }
        }
    }
}
