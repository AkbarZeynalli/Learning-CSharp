namespace TMS_ERD.Dtos
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public string Status { get; set; } = string.Empty; // Open, Closed, Draft
        public DateTime OpenedAt { get; set; }
        public DateTime ClosedAt { get; set; }
    }
}
