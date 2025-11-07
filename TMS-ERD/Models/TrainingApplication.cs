namespace TMS_ERD.Models
{
    public class TrainingApplication : BaseEntity
    {
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }

        // Pending, Approved, Rejected
        public string Status { get; set; } = "Pending";

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Training Training { get; set; }
        public Employee Employee { get; set; }
    }
}
