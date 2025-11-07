namespace TMS_ERD.Dtos
{
    public class TrainingSessionDto
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int SessionNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Location { get; set; }
    }
}
