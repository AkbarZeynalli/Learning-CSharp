using OnlineMovieTicketSalesSystem_EFCORE_.DATA;
using OnlineMovieTicketSalesSystem_EFCORE_.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieTicketSalesSystem_EFCORE_.SERVICES
{
    internal class OperationService
    {
        private AppDbContext appContext;

        public OperationService()
        {
            appContext = new AppDbContext();
        }

        public void AddMovie()
        {
            Movie movie = new Movie();

            Console.Write("Title: ");
            movie.Title = Console.ReadLine() ?? string.Empty;

            Console.Write("Genre: ");
            movie.Genre = Console.ReadLine() ?? string.Empty;

            // Duration
            int duration;
            Console.Write("Duration (in minutes): ");
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.WriteLine("Invalid duration. Please enter a positive integer for minutes.");
                Console.Write("Duration (in minutes): ");
            }
            movie.Duration = duration;

            Console.Write("Director: ");
            movie.Director = Console.ReadLine() ?? string.Empty;

            DateTime releaseDate;
            Console.Write("Release Date (yyyy-MM-dd): ");
            while (!System.DateTime.TryParseExact(
                Console.ReadLine() ?? string.Empty,
                "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out releaseDate))
            {
                Console.WriteLine("Invalid date. Please use the format yyyy-MM-dd (e.g. 2025-09-19).");
                Console.Write("Release Date (yyyy-MM-dd): ");
            }
            movie.ReleaseDate = releaseDate;

            // Rating
            double rating;
            Console.Write("Rating (e.g. 7.5): ");
            while (true)
            {
                var ratingInputRaw = Console.ReadLine() ?? string.Empty;
                var ratingInput = ratingInputRaw.Trim().Replace(',', '.');

                if (double.TryParse(ratingInput, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out rating))
                {
                    if (rating < 0.0 || rating > 10.0)
                    {
                        Console.WriteLine("Rating must be between 0 and 10. Please enter a valid rating.");
                        Console.Write("Rating: ");
                        continue;
                    }
                    break;
                }

                Console.WriteLine("Invalid rating. Please enter a numeric value (use . or , as decimal separator).");
                Console.Write("Rating: ");
            }
            movie.Rating = rating;

            appContext.Movies.Add(movie);
            appContext.SaveChanges();
            try
            {
                appContext.SaveChanges();
                Console.WriteLine("Movie added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving movie: {ex.Message}");
            }
        }

        public void AddCinemaHall()
        {
            CinemaHall cinemaHall = new CinemaHall();

            // Name
            Console.Write("Name: ");
            string? nameInput = Console.ReadLine()?.Trim();
            while (string.IsNullOrEmpty(nameInput))
            {
                Console.WriteLine("Name cannot be empty. Please enter a valid name.");
                Console.Write("Name: ");
                nameInput = Console.ReadLine()?.Trim();
            }
            cinemaHall.Name = nameInput;

            // Location
            Console.Write("Location: ");
            string? locationInput = Console.ReadLine()?.Trim();
            while (string.IsNullOrEmpty(locationInput))
            {
                Console.WriteLine("Location cannot be empty. Please enter a valid location.");
                Console.Write("Location: ");
                locationInput = Console.ReadLine()?.Trim();
            }
            cinemaHall.Location = locationInput;

            // Capacity
            int capacity;
            Console.Write("Capacity: ");
            while (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
            {
                Console.WriteLine("Invalid capacity. Please enter a positive integer.");
                Console.Write("Capacity: ");
            }
            cinemaHall.Capacity = capacity;

            appContext.CinemaHalls.Add(cinemaHall);
            try
            {
                appContext.SaveChanges();
                Console.WriteLine("Cinema hall added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving cinema hall: {ex.Message}");
            }
        }

        public void AddShowtime()
        {
            Showtime showtime = new Showtime();
            var movies = appContext.Movies.ToList();
            var cinemaHalls = appContext.CinemaHalls.ToList();
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies available. Please add a movie first.");
                return;
            }
            if (cinemaHalls.Count == 0)
            {
                Console.WriteLine("No cinema halls available. Please add a cinema hall first.");
                return;
            }
            Console.WriteLine("Available Movies:");
            foreach (var movie in movies)
            {
                Console.WriteLine($"Id: {movie.ID}, Title: {movie.Title}");
            }
            Console.Write("Select a movie by ID: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            var selectedMovie = movies.FirstOrDefault(m => m.ID == movieId);
            if (selectedMovie == null)
            {
                Console.WriteLine("Invalid movie ID.");
                return;
            }
            showtime.MovieId = movieId;
            Console.WriteLine("Available Cinema Halls:");
            foreach (var hall in cinemaHalls)
            {
                Console.WriteLine($"Id: {hall.ID}, Name: {hall.Name}");
            }
            Console.Write("Select a cinema hall by ID: ");
            int hallId = Convert.ToInt32(Console.ReadLine());
            var selectedHall = cinemaHalls.FirstOrDefault(h => h.ID == hallId);
            if (selectedHall == null)
            {
                Console.WriteLine("Invalid cinema hall ID.");
                return;
            }
            showtime.CinemaHallId = hallId;
            Console.Write("Showtime (yyyy-mm-dd HH:mm): ");
            showtime.StartTime = Convert.ToDateTime(Console.ReadLine());
            appContext.Showtimes.Add(showtime);
            appContext.SaveChanges();
        }

        public void AddCustomer()
        {
            Customer customer = new Customer();
            Console.Write("First Name: ");
            customer.Name = Console.ReadLine();
            Console.Write("Email: ");
            customer.Email = Console.ReadLine();
            Console.Write("Phone Number: ");
            customer.PhoneNumber = Console.ReadLine();
            appContext.Customers.Add(customer);
            appContext.SaveChanges();
        }

        public void AddTicket()
        {
            Ticket ticket = new Ticket();
            var showtimes = appContext.Showtimes.ToList();
            var customers = appContext.Customers.ToList();
            if (showtimes.Count == 0)
            {
                Console.WriteLine("No showtimes available. Please add a showtime first.");
                return;
            }
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers available. Please add a customer first.");
                return;
            }
            Console.WriteLine("Available Showtimes:");
            foreach (var showtime in showtimes)
            {
                var movie = appContext.Movies.Find(showtime.MovieId);
                var hall = appContext.CinemaHalls.Find(showtime.CinemaHallId);
                Console.WriteLine($"Id: {showtime.ID}, Movie: {movie?.Title}, Hall: {hall?.Name}, Start Time: {showtime.StartTime}");
            }
            Console.Write("Select a showtime by ID: ");
            int showtimeId = Convert.ToInt32(Console.ReadLine());
            var selectedShowtime = showtimes.FirstOrDefault(s => s.ID == showtimeId);
            if (selectedShowtime == null)
            {
                Console.WriteLine("Invalid showtime ID.");
                return;
            }
            ticket.ShowtimeId = showtimeId;
            Console.WriteLine("Available Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: {customer.ID}, Name: {customer.Name}");
            }
            Console.Write("Select a customer by ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            var selectedCustomer = customers.FirstOrDefault(c => c.ID == customerId);
            if (selectedCustomer == null)
            {
                Console.WriteLine("Invalid customer ID.");
                return;
            }
            ticket.CustomerId = customerId;
            Console.Write("Seat Number: ");
            ticket.SeatNumber = Console.ReadLine();
            ticket.PurchaseDate = DateTime.Now;
            appContext.Tickets.Add(ticket);
            appContext.SaveChanges();

        }

        public void AddPayment()
        {
            Payment payment = new Payment();
            var tickets = appContext.Tickets.ToList();
            if (tickets.Count == 0)
            {
                Console.WriteLine("No tickets available. Please add a ticket first.");
                return;
            }
            Console.WriteLine("Available Tickets:");
            foreach (var ticket in tickets)
            {
                var showtime = appContext.Showtimes.Find(ticket.ShowtimeId);
                var movie = appContext.Movies.Find(showtime.MovieId);
                Console.WriteLine($"Id: {ticket.ID}, Movie: {movie?.Title}, Seat Number: {ticket.SeatNumber}");
            }
            Console.Write("Select a ticket by ID: ");
            int ticketId = Convert.ToInt32(Console.ReadLine());
            var selectedTicket = tickets.FirstOrDefault(t => t.ID == ticketId);
            if (selectedTicket == null)
            {
                Console.WriteLine("Invalid ticket ID.");
                return;
            }
            payment.TicketId = ticketId;
            Console.Write("Amount: ");
            payment.Amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("1-withCard,2-Cash");
            int methodType=int.Parse(Console.ReadLine());
            if (Enum.IsDefined(typeof(PaymentMethodType), methodType))
            {
                payment.PaymentMethodType = (PaymentMethodType)methodType;
            }
       
            payment.PaymentDate = DateTime.Now;
            appContext.Payments.Add(payment);
            appContext.SaveChanges();
        }

        public void AddReview()
        {
            // Step 1
            var movies = appContext.Movies.ToList();
            var customers = appContext.Customers.ToList();

            // Step 2
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies available. Please add a movie first.");
                return;
            }
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers available. Please add a customer first.");
                return;
            }

            // Step 3 - select movie
            Console.WriteLine("Available Movies:");
            foreach (var movie in movies)
            {
                Console.WriteLine($"Id: {movie.ID}, Title: {movie.Title}");
            }
            Console.Write("Select a movie by ID: ");
            if (!int.TryParse(Console.ReadLine(), out int movieId))
            {
                Console.WriteLine("Invalid input. Expected a numeric movie ID.");
                return;
            }
            var selectedMovie = movies.FirstOrDefault(m => m.ID == movieId);
            if (selectedMovie == null)
            {
                Console.WriteLine("Invalid movie ID.");
                return;
            }

            // Step 4 - select customer
            Console.WriteLine("Available Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Id: {customer.ID}, Name: {customer.Name}");
            }
            Console.Write("Select a customer by ID: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid input. Expected a numeric customer ID.");
                return;
            }
            var selectedCustomer = customers.FirstOrDefault(c => c.ID == customerId);
            if (selectedCustomer == null)
            {
                Console.WriteLine("Invalid customer ID.");
                return;
            }

            // Step 5 - rating (1-5)
            int rating;
            while (true)
            {
                Console.Write("Rating (1-5): ");
                var ratingInput = Console.ReadLine();
                if (!int.TryParse(ratingInput, out rating) || rating < 1 || rating > 5)
                {
                    Console.WriteLine("Invalid rating. Please enter an integer between 1 and 5.");
                    continue;
                }
                break;
            }

            // Step 6 - comment
            Console.Write("Comment (optional): ");
            string comment = Console.ReadLine() ?? string.Empty;

            // Step 7 - create review
            Review review = new Review
            {
                MovieID = movieId,
                CustomerID = customerId,
                Rating = rating,
                Comment = comment,
                CreatedAt = DateTime.Now
            };

            // Step 8
            appContext.Reviews.Add(review);
            appContext.SaveChanges();

            // Step 9
            Console.WriteLine("Review added successfully.");
        }
    }

}
