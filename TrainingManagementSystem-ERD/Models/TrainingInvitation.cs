namespace TrainingManagementSystem_ERD.Models
{
    public class TrainingInvitation : BaseEntity
    {
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SentAt { get; set; }
        public string? Message { get; set; }
        public string? Response { get; set; }

        public Training Training { get; set; }
        public Employee Employee { get; set; }
    }
}
