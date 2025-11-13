using LibraryManagementSystemm.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemm.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Library> Librarys { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<BorrowRecord> BorrowRecords { get; set; }

    }
}
