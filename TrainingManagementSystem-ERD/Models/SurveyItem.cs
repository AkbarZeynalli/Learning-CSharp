namespace TrainingManagementSystem_ERD.Models
{
    public class SurveyItem : BaseEntity
    {
        public int SurveyId { get; set; }
        public int QuestionTemplateId { get; set; }

        public Survey Survey { get; set; }
        public QuestionTemplate QuestionTemplate { get; set; }
    }
}
