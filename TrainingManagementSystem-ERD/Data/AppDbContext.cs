using Microsoft.EntityFrameworkCore;
using TrainingManagementSystem_ERD.Models;
//using TrainingManagementSystem_ERD.Models;

namespace TrainingManagementSystem_ERD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // Əsas modellər
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }

        // Sorğu (Survey) sistemi modelləri
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyItem> SurveyItems { get; set; }
        public DbSet<QuestionTemplate> QuestionTemplates { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }

        // Əlavə (istəyə görə)
        public DbSet<Attendance> Attendances { get; set; }
    }
}
