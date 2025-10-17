namespace TrainingProgramWebApi.Dtos
{
    public class JudgeDto : BaseDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Specialty { get; set; } = string.Empty; // məsələn: "Technical Judge", "Business Judge"
        public string Specialization { get; internal set; }
    }
}
