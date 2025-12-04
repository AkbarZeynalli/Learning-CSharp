using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMSApp.DAL.Models
{
    public class Teacher:BaseEntity
    {
        //add all property for teacher
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Fathername { get; set; }
        public DateTime? Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
