namespace TrainingManagementSystem_ERD.Models
{
    public class TrainingSession : BaseEntity
    {
        public int TrainingId { get; set; }
        public int SessionNumber { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Location { get; set; }

        public Training Training { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
