namespace TMS_ERD.Dtos
{
    public class TrainingInvitationDto
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SentAt { get; set; }
        public string? Message { get; set; }
        public string? Response { get; set; }

        // Əlavə görünməsini istəyirsənsə:
        public string? EmployeeName { get; set; }
        public string? TrainingTitle { get; set; }
    }
}
