using StudentManagementSistemWebApi.Models;

namespace StudentManagementSistemWebApi.Dtos
{
    public class CourseDto:BaseDto
    {
        public string Name { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int Credits { get; set; }

        public int TeacherId { get; set; }
    }
}
