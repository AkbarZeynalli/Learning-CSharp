namespace TMS_ERD.Dtos
{
    public class TrainerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Specialization { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
