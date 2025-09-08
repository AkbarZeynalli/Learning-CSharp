using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentSistem.Models
{
    internal class Teacher:Person
    {       
        public double Salary { get; set; }
        public DateOnly HireDate { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
