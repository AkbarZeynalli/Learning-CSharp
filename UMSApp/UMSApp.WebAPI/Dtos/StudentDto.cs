using System.Collections.Specialized;

namespace UMSApp.WebAPI.Dtos
{
    public record StudentDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
