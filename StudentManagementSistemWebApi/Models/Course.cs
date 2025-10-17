namespace StudentManagementSistemWebApi.Models
{
    public class Course:BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int Credits { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!; 
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
