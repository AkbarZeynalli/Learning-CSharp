using Microsoft.EntityFrameworkCore;
//using StudentManagementSistemWebApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using TrainingProgramWebApi.Models;

namespace StudentManagementSistemWebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Judge> Judges { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingEvaluation> TrainingEvaluations { get; set; }
    }
}