namespace TMS_ERD.Dtos
{
    public class SurveySubmissionDto
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int EmployeeId { get; set; }   
        public DateTime SubmittedAt { get; set; }
        public string? Feedback { get; set; }
        public int? Rating { get; set; }
    }
}
