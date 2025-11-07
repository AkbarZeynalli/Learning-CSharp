namespace TMS_ERD.Models
{
    public class Trainer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Specialization { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<Training>? Trainings { get; set; }
    }
}
