namespace TrainingProgramWebApi.Dtos
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public int TrainingSessionId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime? CheckInAt { get; set; }
        public DateTime? CheckOutAt { get; set; }
        public bool IsPresent { get; set; }
    }
}
