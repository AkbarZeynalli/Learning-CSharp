using Microsoft.EntityFrameworkCore;
using Pharmacy.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
