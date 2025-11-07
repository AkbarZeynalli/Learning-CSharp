namespace TMS_ERD.Dtos
{
    public class ParticipantDto
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public bool Completed { get; set; }
        public decimal CompletionPercentage { get; set; }
    }
}
