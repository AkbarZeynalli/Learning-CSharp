using Microsoft.EntityFrameworkCore;
using Rent_a_Car_Management_System.Models;

namespace Rent_a_Car_Management_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Brand → CarModel
            modelBuilder.Entity<CarModel>()
                .HasOne(cm => cm.Brand)
                .WithMany(b => b.Models)
                .HasForeignKey(cm => cm.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            // Brand → Car
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            // CarModel → Car
            modelBuilder.Entity<Car>()
                .HasOne(c => c.CarModel)
                .WithMany(cm => cm.Cars)
                .HasForeignKey(c => c.CarModelId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
