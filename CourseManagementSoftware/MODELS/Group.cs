// Group.cs
namespace CourseManagementSoftware.MODELS
{
    internal class Group : BaseEntity
    {
        public Group() { } // EF Core üçün vacib

        public string Code { get; set; } = string.Empty; // Qrup kodu (unikal olmalıdır)
        public string Name { get; set; } = string.Empty;

        // əlaqələr (FK-lər) — sadə saxlayırıq: TeacherId, MentorId, StudentIds
        public int? TeacherId { get; set; }
        public int? MentorId { get; set; }

        // Student-ların nömrələrini saxlayacağıq (sadə yanaşma)
        public List<int> StudentIds { get; set; } = new List<int>();
    }
}
