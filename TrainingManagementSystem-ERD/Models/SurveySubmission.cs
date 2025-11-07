namespace TrainingManagementSystem_ERD.Models
{
    public class SurveySubmission : BaseEntity
    {
        public int SurveyId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SubmittedAt { get; set; }

        public Survey Survey { get; set; }
        public Employee Employee { get; set; }
        public ICollection<SurveyAnswer> Answers { get; set; }
    }
}
