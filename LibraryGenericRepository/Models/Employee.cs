using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagamentSistem.Models
{
    internal class Employee : Person
    {

        public string Position { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }

        public int LibraryId { get; set; }
        public Library Library { get; set; }
    }
}
