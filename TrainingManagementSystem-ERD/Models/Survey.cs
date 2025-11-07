namespace TrainingManagementSystem_ERD.Models
{
    public class Survey : BaseEntity
    {
        public int TrainingId { get; set; }
        public string Status { get; set; } // Open, Closed
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public Training Training { get; set; }
        public ICollection<SurveyItem> Items { get; set; }
        public ICollection<SurveySubmission> Submissions { get; set; }
    }
}
