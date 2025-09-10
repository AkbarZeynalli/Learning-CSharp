using ProfessionalFootballLeague_EFCORE_.Services;

namespace ProfessionalFootballLeague_EFCORE_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int mainChoice;
            do
            {
                Console.WriteLine("\n===== ƏSAS MENYU =====");
                Console.WriteLine("1. Hesabat menyusu");
                Console.WriteLine("2. Əməliyyat menyusu");
                Console.WriteLine("3. Exit");
                mainChoice = ReadInt("Seçiminiz: ");

                switch (mainChoice)
                {
                    case 1:
                        ShowReportsMenu();
                        break;
                    case 2:
                        ShowOperationsMenu();
                        break;
                    case 3:
                        Console.WriteLine("Proqramdan çıxılır...");
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim. Yenidən cəhd edin.");
                        break;
                }
            } while (mainChoice != 3);
        }

        static void ShowReportsMenu()
        {
            OperationService operationService = new OperationService();

            int reportChoice;
            do
            {
                Console.WriteLine("\n===== HESABAT MENYUSU =====");
                Console.WriteLine("1. Kamandaları görüntülə");
                Console.WriteLine("2. kamandaya görə futbolçular");
                Console.WriteLine("3. Futbolçunun atdığı qol sayısı");
                Console.WriteLine("4. Ən çox qol atan və yeyən komandalar");
                Console.WriteLine("5. Ən çox qol atan futbolçu");
                Console.WriteLine("6. Geri");
                reportChoice = ReadInt("Seçiminiz: ");

                switch (reportChoice)
                {
                    case 1:
                        Console.WriteLine("Kamandaları görüntülə");
                        operationService.GetAllTeams();
                        break;
                    case 2:
                        var teamId = ReadInt("Futbolçularını görmək istədiyiniz komandanın ID-sini daxil edin: ");
                        operationService.GetAllPlayers(teamId);
                        break;
                    case 3:
                        var playerId = ReadInt("Qol sayını görmək istədiyiniz futbolçunun ID-sini daxil edin: ");
                        operationService.GetPlayerGoals(playerId);
                        break;
                    case 4:
                        operationService.GetTopScoringAndConcedingTeams();

                        break;
                    case 5:
                        operationService.GetTopScoringPlayer();
                        break;
                    case 6:
                        Console.WriteLine("Hesabat menyusundan çıxılır...");
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim. Yenidən cəhd edin.");
                        break;
                }
            } while (reportChoice != 6);
        }

        static void ShowOperationsMenu()
        {
            OperationService operationService = new OperationService();
            int choice;
            do
            {
                Console.WriteLine("\n===== ƏMƏLİYYAT MENYUSU =====");
                Console.WriteLine("1. Komanda əlavə et");
                Console.WriteLine("2. Futbolçu əlavə et");
                Console.WriteLine("3. Oyun əlavə et");
                Console.WriteLine("4. Geri");
                choice = ReadInt("Seçiminiz: ");

                switch (choice)
                {
                    case 1:
                        operationService.AddTeam();
                        break;
                    case 2:
                        operationService.AddPlayer();
                        break;
                    case 3:
                        operationService.AddGame();
                        break;
                    case 4:
                        Console.WriteLine("Əməliyyat menyusundan çıxılır...");
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim. Yenidən cəhd edin.");
                        break;
                }
            } while (choice != 4);
        }

        static int ReadInt(string prompt)
        {
            int value;
            Console.Write(prompt);
            string? input = Console.ReadLine();
            while (!int.TryParse(input, out value))
            {
                Console.Write("Düzgün ədəd daxil edin: ");
                input = Console.ReadLine();
            }
            return value;
        }
    }
}
