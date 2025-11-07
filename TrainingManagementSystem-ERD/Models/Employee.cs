namespace TrainingManagementSystem_ERD.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<TrainingApplication> TrainingApplications { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<TrainingInvitation> TrainingInvitations { get; set; }
        public ICollection<SurveySubmission> SurveySubmissions { get; set; }
    }
}
