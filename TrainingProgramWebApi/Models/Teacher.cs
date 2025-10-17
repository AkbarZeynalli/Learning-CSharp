namespace TrainingProgramWebApi.Models
{
    public class Teacher : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Expertise { get; set; } = string.Empty; // məsələn: "Software Engineering", "Math", və s.

        // Bir müəllim bir neçə təlim yarada bilər
        public ICollection<Training> Trainings { get; set; } = new List<Training>();
    }
}
