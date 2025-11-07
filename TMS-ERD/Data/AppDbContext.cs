using Microsoft.EntityFrameworkCore;
using TMS_ERD.Models;

namespace TMS_ERD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // --- DbSet-lər ---
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        // Survey sistemi
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyItem> SurveyItems { get; set; }
        public DbSet<QuestionTemplate> QuestionTemplates { get; set; }
        public DbSet<SurveySubmission> SurveySubmissions { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Training sistemi əlaqələri ---

            // Attendance → TrainingSession (No cascade delete)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.TrainingSession)
                .WithMany(ts => ts.Attendances)
                .HasForeignKey(a => a.TrainingSessionId)
                .OnDelete(DeleteBehavior.NoAction);

            // Attendance → Participant (No cascade delete)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Participant)
                .WithMany(p => p.Attendances)
                .HasForeignKey(a => a.ParticipantId)
                .OnDelete(DeleteBehavior.NoAction);

            // Participant → Training (No cascade delete)
            modelBuilder.Entity<Participant>()
                .HasOne(p => p.Training)
                .WithMany()
                .HasForeignKey(p => p.TrainingId)
                .OnDelete(DeleteBehavior.NoAction);

            // TrainingSession → Training (No cascade delete)
            modelBuilder.Entity<TrainingSession>()
                .HasOne(ts => ts.Training)
                .WithMany()
                .HasForeignKey(ts => ts.TrainingId)
                .OnDelete(DeleteBehavior.NoAction);


            // --- Survey sistemi əlaqələri ---

            // SurveyAnswer → SurveySubmission (No cascade delete)
            modelBuilder.Entity<SurveyAnswer>()
                .HasOne(sa => sa.SurveySubmission)
                .WithMany(ss => ss.Answers)
                .HasForeignKey(sa => sa.SurveySubmissionId)
                .OnDelete(DeleteBehavior.NoAction);


            // SurveyAnswer → SurveyItem (No cascade delete)
            modelBuilder.Entity<SurveyAnswer>()
                .HasOne(sa => sa.SurveyItem)
                .WithMany(si => si.SurveyAnswers)
                .HasForeignKey(sa => sa.SurveyItemId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
