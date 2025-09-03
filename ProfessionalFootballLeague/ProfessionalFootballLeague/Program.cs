using System;

namespace ProfessionalFootballLeague
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperationManagamentSistem operationManagamentSistem = new OperationManagamentSistem();
            int choice = 0;

            do
            {
                Console.WriteLine("\n--- Professional Football League ---");
                Console.WriteLine("1. Add LEAGUE ");
                Console.WriteLine("2. Add TEAM ");
                Console.WriteLine("3. Add PLAYER ");
                Console.WriteLine("4. Show LEAGUE ");
                Console.WriteLine("5. Show TEAM ");
                Console.WriteLine("6. Show PLAYER ");
                Console.WriteLine("7. Exit ");
                Console.Write("Choose an option: ");

                // Təhlükəsiz oxuma
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("⚠️ Please enter a valid number!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        operationManagamentSistem.AddLeauge();
                        break;
                    case 2:
                        operationManagamentSistem.AddTeam();
                        break;
                    case 3:
                        operationManagamentSistem.AddPlayer();
                        break;
                    case 4:
                        operationManagamentSistem.ShowLeagues();
                        break;
                    case 5:
                        operationManagamentSistem.ShowTeams();
                        break;
                    case 6:
                        operationManagamentSistem.ShowPlayers();
                        break;
                    case 7:     
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("⚠️ Invalid choice. Try again!");
                        break;
                }
            }
            while (choice != 7);
        }
    }
}
