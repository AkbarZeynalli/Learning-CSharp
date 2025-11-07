namespace TMS_ERD.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; } // GET və PUT üçün lazımdır
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
