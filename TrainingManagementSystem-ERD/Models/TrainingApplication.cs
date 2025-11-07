namespace TrainingManagementSystem_ERD.Models
{
    public class TrainingApplication : BaseEntity
    {
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public DateTime AppliedAt { get; set; }

        public Training Training { get; set; }
        public Employee Employee { get; set; }
    }
}
