namespace TrainingProgramWebApi.Models
{
    public class Training : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<TrainingEvaluation> Evaluations { get; set; } = new List<TrainingEvaluation>();
    }
}
