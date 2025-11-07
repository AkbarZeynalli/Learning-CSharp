namespace TMS_ERD.Models
{
    public class Attendance : BaseEntity
    {
        public int TrainingSessionId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime? CheckInAt { get; set; }
        public DateTime? CheckOutAt { get; set; }
        public bool IsPresent { get; set; }

        public TrainingSession TrainingSession { get; set; }
        public Participant Participant { get; set; }
    }
}
