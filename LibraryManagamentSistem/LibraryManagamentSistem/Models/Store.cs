using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagamentSistem.Models
{
    internal class Store
    {
        public List<Library> LibraryList { get; set; } 
        public List<Book> BookList { get; set; }
        public List<Customer> CustomerList { get; set; }
        public  List<Employee> EmployeeList { get; set; }

        public Store()
        {
            LibraryList = new List<Library>();
            BookList = new List<Book>();
            CustomerList = new List<Customer>();
            EmployeeList = new List<Employee>();
        }

    }
}
