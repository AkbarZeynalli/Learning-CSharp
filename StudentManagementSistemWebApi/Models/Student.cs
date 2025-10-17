namespace StudentManagementSistemWebApi.Models
{
    public class Student:Person
    {
        public string? Grade { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
