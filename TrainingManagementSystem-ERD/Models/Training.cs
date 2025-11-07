namespace TrainingManagementSystem_ERD.Models
{

        public class Training : BaseEntity
        {
            public string Title { get; set; }
            public string? Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Mode { get; set; } // Online, Offline, Hybrid
            public int Capacity { get; set; }

            // Relations
            public ICollection<Participant> Participants { get; set; }
            public ICollection<TrainingApplication> Applications { get; set; }
            public ICollection<TrainingSession> Sessions { get; set; }
            public ICollection<TrainingInvitation> Invitations { get; set; }
            public ICollection<Survey> Surveys { get; set; }

            public int TrainerId { get; set; }
            public Trainer Trainer { get; set; }
        }

}
