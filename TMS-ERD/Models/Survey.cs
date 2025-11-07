namespace TMS_ERD.Models
{
    public class Survey : BaseEntity
    {
        public int TrainingId { get; set; }
        public string Status { get; set; } = string.Empty; // Open, Closed, Draft
        public DateTime OpenedAt { get; set; }
        public DateTime? ClosedAt { get; set; } // 🔹 Nullable olaraq
        public Training Training { get; set; }
        public ICollection<SurveyItem> SurveyItems { get; set; }
        public ICollection<SurveySubmission> SurveySubmissions { get; set; }
    }
}
