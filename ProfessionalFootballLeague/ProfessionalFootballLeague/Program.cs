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
                Console.WriteLine("1. Add LEAGUE ");
                Console.WriteLine("2. Add TEAM ");
                Console.WriteLine("3. Add PLAYER ");
                Console.WriteLine("4. Show LEAGUE ");
                Console.WriteLine("5. Show TEAM ");
                Console.WriteLine("6. Show PLAYER ");
                Console.WriteLine("7. Exit ");
                choice = int.Parse(Console.ReadLine());

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
                        // Code to show league
                        break;
                    case 5:
                        // Code to show team
                        break;
                    case 6:
                        // Code to show player
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                }
            }
            while (choice != 7);


        }
    }
}
