using Microsoft.EntityFrameworkCore;
using OnlineMovieTicketSalesSystem_EFCORE_.MODELS;

namespace OnlineMovieTicketSalesSystem_EFCORE_.DATA
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=DESKTOP-H6VMCSI\\SQLEXPRESS;Initial Catalog=MovieTicketDB;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaHall> CinemaHalls { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews{ get; set; }
    }
}
