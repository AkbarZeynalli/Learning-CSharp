using OnlineMovieTicketSalesSystem_EFCORE_.SERVICES;

namespace OnlineMovieTicketSalesSystem_EFCORE_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperationService operationService = new OperationService();
            int choice = 0;
            do
            {
                Console.WriteLine("\n===== ƏSAS MENYU =====");
                Console.WriteLine("1. Movie");
                Console.WriteLine("2. CinemaHall");
                Console.WriteLine("3. Showtime");
                Console.WriteLine("4. Customer");
                Console.WriteLine("5. Ticket (Bilet)");
                Console.WriteLine("6. Payment");
                Console.WriteLine("7. Review");
                Console.WriteLine("8. Çıxış");
                Console.Write("Seçim: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        operationService.AddMovie();
                        break;
                    case 2:
                        operationService.AddCinemaHall();
                        break;
                    case 3:
                        operationService.AddShowtime();
                        break;
                    case 4:
                        operationService.AddCustomer();
                        break;
                    case 5:
                        operationService.AddTicket();
                        break;
                    case 6:
                        operationService.AddPayment();
                        break;
                    case 7:
                        operationService.AddReview();
                        break;
                }
            } while (choice != 8);
        }
    }
}
