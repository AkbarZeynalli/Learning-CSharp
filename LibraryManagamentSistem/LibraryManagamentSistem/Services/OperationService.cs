using LibraryManagamentSistem.Data;
using LibraryManagamentSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagamentSistem.Services
{
    internal class OperationService
    {
        private AppDbContext appContext;
        public OperationService()
        {
            appContext = new AppDbContext();
        }

        public void AddLibrary()
        {
            Library library = new Library();
            Console.Write("Enter Library Name: ");
            library.Name = Console.ReadLine();
            Console.Write("Enter Library Address: ");
            library.Address = Console.ReadLine();
            appContext.Libraries.Add(library);
            appContext.SaveChanges();
        }

        public void AddEmployee()
        {
            Employee employee = new Employee();
            var libraries = appContext.Libraries.ToList();
            if (libraries.Count == 0)
            {
                Console.WriteLine("No libraries found. Please add a library first.");
                return;
            }
            Console.WriteLine("Available Libraries:");
            foreach (var lib in libraries)
            {
                Console.WriteLine($"ID: {lib.Id}, Name: {lib.Name}");
            }
            Console.Write("Enter Library ID to associate with the Employee: ");
            int libraryId = int.Parse(Console.ReadLine());
            employee.LibraryId = libraryId;

            Console.WriteLine("Enter Employee Name:");
            employee.Name = Console.ReadLine();
            Console.Write("Enter Employee Surname: ");
            employee.Surname = Console.ReadLine();
            Console.Write("Enter Employee Age:(yyyy-MM-dd) ");
            employee.Age = DateOnly.Parse(Console.ReadLine());
            Console.Write("Enter Employee Position: ");
            employee.Position = Console.ReadLine();
            Console.Write("Enter Employee Phone Number: ");
            employee.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Employee Email: ");
            employee.Email = Console.ReadLine();
            Console.Write("Enter Employee Address: ");
            employee.Address = Console.ReadLine();
            Console.Write("Enter Employee Salary: ");
            employee.Salary = double.Parse(Console.ReadLine());
            employee.HireDate = DateTime.Now;
            appContext.Employees.Add(employee);
            appContext.SaveChanges();

        }

        public void AddCustomer()
        {

            Customer customer = new Customer();

            var libraries = appContext.Libraries.ToList();
            if (libraries.Count == 0)
            {
                Console.WriteLine("No libraries found. Please add a library first.");
                return;
            }
            Console.WriteLine("Available Libraries:");
            foreach (var lib in libraries)
            {
                Console.WriteLine($"ID: {lib.Id}, Name: {lib.Name}");
            }
            Console.Write("Enter Library ID to associate with the Customer: ");
            int libraryId = int.Parse(Console.ReadLine());
            customer.LibraryId = libraryId;
            Console.WriteLine("Enter Customer Name:");
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
            appContext.Customers.Add(customer);
            appContext.SaveChanges();
        }

        public void AddBook()
        {
            Book book = new Book();
            var libraries = appContext.Libraries.ToList();
            if (libraries.Count == 0)
            {
                Console.WriteLine("No libraries found. Please add a library first.");
                return;
            }
            Console.WriteLine("Available Libraries:");
            foreach (var lib in libraries)
            {
                Console.WriteLine($"ID: {lib.Id}, Name: {lib.Name}");
            }
            Console.Write("Enter Library ID to associate with the Book: ");
            int libraryId = int.Parse(Console.ReadLine());
            book.LibraryId = libraryId;
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
            appContext.Books.Add(book);
            appContext.SaveChanges();
        }

    }
}
