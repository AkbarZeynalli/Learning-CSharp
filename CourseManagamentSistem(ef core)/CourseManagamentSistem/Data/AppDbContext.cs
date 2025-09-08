using CourseManagamentSistem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentSistem.Data
{
    internal class AppDbContext: DbContext
    {
        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=DESKTOP-H6VMCSI\\SQLEXPRESS;Initial Catalog=CourseDB;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
