namespace TMS_ERD.Models
{
    public class Training : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Mode { get; set; } 
        public int Capacity { get; set; }

        // Relations
        public ICollection<Participant> Participants { get; set; } = new List<Participant>();
        public ICollection<TrainingApplication> Applications { get; set; } = new List<TrainingApplication>();
        public ICollection<TrainingSession> Sessions { get; set; } = new List<TrainingSession>();
        public ICollection<TrainingInvitation> Invitations { get; set; } = new List<TrainingInvitation>();
        public ICollection<Survey> Surveys { get; set; } = new List<Survey>();

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;
    }
}
