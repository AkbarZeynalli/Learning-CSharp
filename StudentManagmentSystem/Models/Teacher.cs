using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSystem.Models
{
    internal class Teacher : Person
    {
        public string Subject { get; set; }
        public ICollection<Course> Courses { get; set; }

    }
}
