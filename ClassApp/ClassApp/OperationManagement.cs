using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassApp
{
    internal class OperationManagement
    {

        Store store = new Store();
        public void AddLibrary()
        {
            Library library = new Library();
            Console.Write("Enter Library Name: ");
            library.Name = Console.ReadLine();
            Console.Write("Enter Library Address: ");
            library.Address = Console.ReadLine();
            library.Id = store.LibraryList.Count + 1;
            store.LibraryList.Add(library);
        }
        public void AddEmployee()
        {
            foreach (var item in store.LibraryList)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name}");
            }
            Console.Write("Select Library by Id: ");
            int libraryId = int.Parse(Console.ReadLine());
            Employee employee = new Employee();
            Console.Write("Enter Employee Name: ");
            employee.Name = Console.ReadLine();
            Console.Write("Enter Employee Surname: ");
            employee.Surname = Console.ReadLine();
            Console.Write("Enter Employee Age:(yyyy-MM-dd) ");
            employee.Age = DateOnly.Parse(Console.ReadLine());
            Console.Write("Enter Employee Position: ");
            employee.Position = Console.ReadLine();
            Console.Write("Enter Employee Salary: ");
            employee.Salary = double.Parse(Console.ReadLine());
            Console.Write("Enter Employee Phone Number: ");
            employee.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Employee Email: ");
            employee.Email = Console.ReadLine();
            Console.Write("Enter Employee Address: ");
            employee.Address = Console.ReadLine();
            employee.HireDate = DateTime.Now;
            store.EmployeeList.Add(employee);
            Console.WriteLine("Employee Added");
            employee.Id = store.EmployeeList.Count + 1;
            employee.LibraryId = libraryId;
        }
        public void AddCustomer()
        {
            foreach (var item in store.LibraryList)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name}");
            }
            Console.Write("Select Library by Id: ");
            int libraryId = int.Parse(Console.ReadLine());

            Customer customer = new Customer();
            Console.Write("Enter Customer Name: ");
            customer.Name = Console.ReadLine();
            Console.Write("Enter Customer Surname: ");
            customer.Surname = Console.ReadLine();
            Console.Write("Enter Customer Age:(yyyy-MM-dd) ");
            customer.Age = DateOnly.Parse(Console.ReadLine());
            Console.Write("Enter Customer Phone Number: ");
            customer.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Customer Email: ");
            customer.Email = Console.ReadLine();
            Console.Write("Enter Customer Address: ");
            customer.Address = Console.ReadLine();
            customer.MembershipDate = DateTime.Now;
            customer.Id = store.CustomerList.Count + 1;
            store.CustomerList.Add(customer);
            Console.WriteLine("Customer Added");
            customer.LibraryId = libraryId;

        }
        public void AddBook()
        {
            foreach (var item in store.LibraryList)
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name}");
            }
            Console.Write("Select Library by Id: ");
            int libraryId = int.Parse(Console.ReadLine());

            foreach (var item in store.EmployeeList.Where(e => e.LibraryId == libraryId))
            {
                Console.WriteLine($"Id: {item.Id} Name: {item.Name} Surname: {item.Surname}");
            }
            Console.Write("Select Employee by Id: ");
            int employeeId = int.Parse(Console.ReadLine());

            Book book = new Book();
            Console.Write("Enter Book Name: ");
            book.Name = Console.ReadLine();
            Console.Write("Enter Book Author: ");
            book.Author = Console.ReadLine();
            Console.Write("Enter Book Year: ");
            book.Year = int.Parse(Console.ReadLine());
            Console.Write("Enter Book Genre: ");
            book.Genre = Console.ReadLine();
            Console.Write("Enter Book Publisher: ");
            book.Publisher = Console.ReadLine();
            Console.Write("Enter Book Page Count: ");
            book.PageCount = int.Parse(Console.ReadLine());
            Console.Write("Enter Book Language: ");
            book.Language = Console.ReadLine();
            book.Id = store.BookList.Count + 1;
            store.BookList.Add(book);
            book.LibraryId = libraryId;
            book.Id = employeeId;
        }
    }
}
