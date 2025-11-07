namespace TrainingManagementSystem_ERD.Models
{
    public class QuestionTemplate : BaseEntity
    {
        public string Text { get; set; }
        public string Type { get; set; } // Likert, Rating, Text, MultipleChoice
        public bool IsActive { get; set; } = true;
        public string? Options { get; set; } // optional, JSON string kimi saxlanıla bilər

        public ICollection<SurveyItem> SurveyItems { get; set; }
    }
}
