namespace StudentManagementSistemWebApi.Dtos
{
    public class TeacherDto:BaseDto
    {

        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Subject { get; set; }
    }
}
