namespace TrainingProgramWebApi.Dtos
{
    public class TeacherDto : BaseDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Expertise { get; set; } = string.Empty; // məsələn: "Software Development", "Data Science"
    }
}
