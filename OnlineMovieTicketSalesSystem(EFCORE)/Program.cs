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
        // ================= MOVIE ==================
        //static void MovieMenu(OperationService service)
        //{
        //    int choice = 0;
        //    do
        //    {
        //        Console.WriteLine("\n--- MOVIE MENYU ---");
        //        Console.WriteLine("1. Əlavə et");
        //        Console.WriteLine("2. Siyahıla (filtr: janr / başlıq / reyting)");
        //        Console.WriteLine("3. Yenilə");
        //        Console.WriteLine("4. Sil");
        //        Console.WriteLine("5. Geri dön");
        //        Console.Write("Seçim: ");
        //        choice = Convert.ToInt32(Console.ReadLine());

        //        switch (choice)
        //        {
        //            case 1: service.AddMovie(); break;
        //            case 2:
        //                Console.WriteLine("Filtr seçin: 1-Janr, 2-Başlıq, 3-Reyting");
        //                int filter = Convert.ToInt32(Console.ReadLine());
        //                service.ListMovies(filter);
        //                break;
        //            case 3: service.UpdateMovie(); break;
        //            case 4: service.DeleteMovie(); break;
        //        }
        //    } while (choice != 5);
        //}

        //// ================= CINEMAHALL ==================
        //static void CinemaHallMenu(OperationService service)
        //{
        //    int choice = 0;
        //    do
        //    {
        //        Console.WriteLine("\n--- CINEMAHALL MENYU ---");
        //        Console.WriteLine("1. Əlavə et");
        //        Console.WriteLine("2. Siyahıla");
        //        Console.WriteLine("3. Yenilə");
        //        Console.WriteLine("4. Sil");
        //        Console.WriteLine("5. Geri dön");
        //        Console.Write("Seçim: ");
        //        choice = Convert.ToInt32(Console.ReadLine());

        //        switch (choice)
        //        {
        //            case 1: service.AddCinemaHall(); break;
        //            case 2: service.ListCinemaHalls(); break;
        //            case 3: service.UpdateCinemaHall(); break;
        //            case 4: service.DeleteCinemaHall(); break;
        //        }
        //    } while (choice != 5);
        //}

        //// ================= SHOWTIME ==================
        //static void ShowtimeMenu(OperationService service)
        //{
        //    int choice = 0;
        //    do
        //    {
        //        Console.WriteLine("\n--- SHOWTIME MENYU ---");
        //        Console.WriteLine("1. Əlavə et");
        //        Console.WriteLine("2. Siyahıla");
        //        Console.WriteLine("3. Yenilə");
        //        Console.WriteLine("4. Sil");
        //        Console.WriteLine("5. Geri dön");
        //        Console.Write("Seçim: ");
        //        choice = Convert.ToInt32(Console.ReadLine());

        //        switch (choice)
        //        {
        //            case 1: service.AddShowtime(); break;  // Validasiya: Start < End, overlap yoxlanacaq
        //            case 2: service.ListShowtimes(); break;
        //            case 3: service.UpdateShowtime(); break;
        //            case 4: service.DeleteShowtime(); break;
        //        }
        //    } while (choice != 5);
        //}

        //// ================= CUSTOMER ==================
        //static void CustomerMenu(OperationService service)
        //{
        //    int choice = 0;
        //    do
        //    {
        //        Console.WriteLine("\n--- CUSTOMER MENYU ---");
        //        Console.WriteLine("1. Əlavə et");
        //        Console.WriteLine("2. Siyahıla");
        //        Console.WriteLine("3. Yenilə");
        //        Console.WriteLine("4. Sil");
        //        Console.WriteLine("5. Geri dön");
        //        Console.Write("Seçim: ");
        //        choice = Convert.ToInt32(Console.ReadLine());

        //        switch (choice)
        //        {
        //            case 1: service.AddCustomer(); break; // Email validasiya
        //            case 2: service.ListCustomers(); break;
        //            case 3: service.UpdateCustomer(); break;
        //            case 4: service.DeleteCustomer(); break;
        //        }
        //    } while (choice != 5);
        //}

        //// ================= TICKET ==================
        //static void TicketMenu(OperationService service)
        //{
        //    int choice = 0;
        //    do
        //    {
        //        Console.WriteLine("\n--- TICKET MENYU ---");
        //        Console.WriteLine("1. Bilet al");
        //        Console.WriteLine("2. Siyahıla");
        //        Console.WriteLine("3. Ləğv et");
        //        Console.WriteLine("4. Geri dön");
        //        Console.Write("Seçim: ");
        //        choice = Convert.ToInt32(Console.ReadLine());

        //        switch (choice)
        //        {
        //            case 1: service.PurchaseTicket(); break;
        //            case 2: service.ListTickets(); break;
        //            case 3: service.CancelTicket(); break;
        //        }
        //    } while (choice != 4);
        //}

        //// ================= PAYMENT ==================
        //static void PaymentMenu(OperationService service)
        //{
        //    int choice = 0;
        //    do
        //    {
        //        Console.WriteLine("\n--- PAYMENT MENYU ---");
        //        Console.WriteLine("1. Əlavə et");
        //        Console.WriteLine("2. Siyahıla");
        //        Console.WriteLine("3. Yenilə");
        //        Console.WriteLine("4. Geri dön");
        //        Console.Write("Seçim: ");
        //        choice = Convert.ToInt32(Console.ReadLine());

        //        switch (choice)
        //        {
        //            case 1: service.AddPayment(); break;
        //            case 2: service.ListPayments(); break;
        //            case 3: service.UpdatePayment(); break;
        //        }
        //    } while (choice != 4);
        //}

        //// ================= REVIEW ==================
        //static void ReviewMenu(OperationService service)
        //{
        //    int choice = 0;
        //    do
        //    {
        //        Console.WriteLine("\n--- REVIEW MENYU ---");
        //        Console.WriteLine("1. Əlavə et");
        //        Console.WriteLine("2. Siyahıla");
        //        Console.WriteLine("3. Sil");
        //        Console.WriteLine("4. Geri dön");
        //        Console.Write("Seçim: ");
        //        choice = Convert.ToInt32(Console.ReadLine());

        //        switch (choice)
        //        {
        //            case 1: service.AddReview(); break;
        //            case 2: service.ListReviews(); break;
        //            case 3: service.DeleteReview(); break;
        //        }
        //    } while (choice != 4);
        //}
    }
}
