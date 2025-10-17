namespace StudentManagementSistemWebApi.Models
{
    public class Person:BaseEntity
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
