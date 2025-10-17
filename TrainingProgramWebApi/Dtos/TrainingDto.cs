namespace TrainingProgramWebApi.Dtos
{
    public class TrainingDto:BaseDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TeacherId { get; set; }
        public DateTime Date { get; internal set; }
    }
}
