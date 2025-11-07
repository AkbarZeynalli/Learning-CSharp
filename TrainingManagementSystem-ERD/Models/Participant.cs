namespace TrainingManagementSystem_ERD.Models
{
    public class Participant : BaseEntity
    {
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public bool Completed { get; set; }
        public decimal CompletionPercentage { get; set; }

        public Training Training { get; set; }
        public Employee Employee { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
