namespace StudentManagementSistemWebApi.Models
{
    public class Teacher:Person
    {
        public string Subject { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
