namespace TrainingProgramWebApi.Models
{
    public class TrainingEvaluation : BaseEntity
    {
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public int JudgeId { get; set; }
        public Judge Judge { get; set; }

        public int TeacherId { get; set; } // müəllimlə əlaqə (əgər lazımdırsa)

        public int Score { get; set; } // məsələn: 1–10 arası
        public string Comment { get; set; } = string.Empty; // Hakimin rəyi
    }
}
