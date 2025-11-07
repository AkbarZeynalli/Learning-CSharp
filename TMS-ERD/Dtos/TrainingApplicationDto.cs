namespace TMS_ERD.Dtos
{
    public class TrainingApplicationDto
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public string? TrainingTitle { get; set; }  // opsional, mapping zamanı doldurula bilər
        public string? EmployeeName { get; set; }   // opsional, mapping zamanı doldurula bilər
        public string Status { get; set; } = "Pending";
        public DateTime AppliedAt { get; set; }
    }
}
