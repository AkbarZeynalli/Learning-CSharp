namespace TMS_ERD.Dtos
{
    public class QuestionTemplateDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string? Options { get; set; }
    }
}
