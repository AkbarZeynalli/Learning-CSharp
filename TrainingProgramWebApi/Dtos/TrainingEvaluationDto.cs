namespace TrainingProgramWebApi.Dtos
{
    public class TrainingEvaluationDto : BaseDto
    {
        public int TrainingId { get; set; }
        public int JudgeId { get; set; }
        public int TeacherId { get; set; } // müəllim ID
        public int Score { get; set; } // məsələn: 1-10 arası
        public string Comment { get; set; } = string.Empty; // Hakimin rəyi
    }
}
