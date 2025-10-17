namespace TrainingProgramWebApi.Models
{
    public class Judge : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty; 
        public ICollection<TrainingEvaluation> Evaluations { get; set; } = new List<TrainingEvaluation>();
    }
}
