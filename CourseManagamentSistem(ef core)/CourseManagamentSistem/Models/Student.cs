using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentSistem.Models
{
    internal class Student: Person
    {
        public double Payment { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

    }
}
