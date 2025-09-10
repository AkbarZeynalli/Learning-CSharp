using Microsoft.EntityFrameworkCore;
using ProfessionalFootballLeague_EFCORE_.Models;

namespace ProfessionalFootballLeague_EFCORE_.DATA
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=DESKTOP-H6VMCSI\\SQLEXPRESS;Initial Catalog=FootballDB;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
