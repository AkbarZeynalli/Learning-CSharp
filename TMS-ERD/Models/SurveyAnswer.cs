namespace TMS_ERD.Models
{
    public class SurveyAnswer : BaseEntity
    {
        public int SurveySubmissionId { get; set; }
        public int SurveyItemId { get; set; }
        public string? Value { get; set; }

        public SurveySubmission SurveySubmission { get; set; }
        public SurveyItem SurveyItem { get; set; }
    }
}
