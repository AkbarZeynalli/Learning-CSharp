namespace TrainingManagementSystem_ERD.Models
{
    public class Trainer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Specialization { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Training> Trainings { get; set; }
    }
}
