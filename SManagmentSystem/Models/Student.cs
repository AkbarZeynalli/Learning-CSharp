using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SManagmentSystem.Models
{
    internal class Student: Person
    {
        public string? Grade { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
