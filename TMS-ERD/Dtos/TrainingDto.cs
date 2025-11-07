namespace TMS_ERD.Dtos
{
    public class TrainingDto : BaseDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Mode { get; set; } // Online, Offline, Hybrid
        public int Capacity { get; set; }

        public int TrainerId { get; set; }
    }
}
