using LibraryGenericRepository.Repositories;
using LibraryManagamentSistem.Models;
using SManagmentSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryGenericRepository.Services
{
    internal class OperationManagment
    {
        private GenericRepository<Library> _libraryRepository;
        private GenericRepository<Book> _bookRepository;
        private GenericRepository<Customer> _customerRepository;
        private GenericRepository<Employee> _employeeRepository;

        public OperationManagment()
        {
            _libraryRepository = new GenericRepository<Library>();
            _bookRepository = new GenericRepository<Book>();
            _customerRepository = new GenericRepository<Customer>();
            _employeeRepository = new GenericRepository<Employee>();
        }

        public void AddLibrary()
        {
            Console.Write("Enter Library Name: ");
            string name = Console.ReadLine()?.Trim();
            Console.Write("Enter Library Address: ");
            string address = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Both name and address are required. Library was not added.");
                return;
            }

            var library = new Library
            {
                Name = name,
                Address = address,
                CreatedAt = DateTime.Now
            };

            try
            {
                _libraryRepository.Add(library);
                Console.WriteLine($"Library '{library.Name}' added successfully.");
                // If repository sets Id on save, show it
                if (library.Id > 0)
                {
                    Console.WriteLine($"Assigned Id: {library.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the library: {ex.Message}");
            }
        }
        public void GetLibrary()
        {
            try
            {
                Console.Write("Enter Library Id to view details or press Enter to list all libraries: ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    var libraries = _libraryRepository.GetAll()?.ToList() ?? new List<Library>();
                    if (!libraries.Any())
                    {
                        Console.WriteLine("No libraries found.");
                        return;
                    }

                    Console.WriteLine("Libraries:");
                    foreach (var lib in libraries)
                    {
                        Console.WriteLine($"Id: {lib.Id} | Name: {lib.Name} | Address: {lib.Address} | CreatedAt: {lib.CreatedAt:yyyy-MM-dd HH:mm}");
                    }

                    return;
                }

                if (!int.TryParse(input, out int libraryId))
                {
                    Console.WriteLine("Invalid Id. Please enter a numeric library Id.");
                    return;
                }

                var library = _libraryRepository.GetById(libraryId);
                if (library == null)
                {
                    Console.WriteLine($"Library with Id {libraryId} was not found.");
                    return;
                }

                Console.WriteLine("Library Details:");
                Console.WriteLine($"Id: {library.Id}");
                Console.WriteLine($"Name: {library.Name}");
                Console.WriteLine($"Address: {library.Address}");
                Console.WriteLine($"CreatedAt: {library.CreatedAt:yyyy-MM-dd HH:mm}");

                // Get related counts
                var books = _bookRepository.GetAll() ?? Enumerable.Empty<Book>();
                var employees = _employeeRepository.GetAll() ?? Enumerable.Empty<Employee>();
                var customers = _customerRepository.GetAll() ?? Enumerable.Empty<Customer>();

                int bookCount = books.Count(b => b.LibraryId == libraryId);
                int employeeCount = employees.Count(e => e.LibraryId == libraryId);
                int customerCount = customers.Count(c => c.LibraryId == libraryId);

                Console.WriteLine($"Books: {bookCount} | Employees: {employeeCount} | Customers: {customerCount}");

                // Show up to first 10 book titles for the library
                var sampleBooks = books.Where(b => b.LibraryId == libraryId)
                                       .Select(b => $"{b.Id}: {b.Name} by {b.Author}")
                                       .Take(10)
                                       .ToList();

                if (sampleBooks.Any())
                {
                    Console.WriteLine("Sample Books:");
                    foreach (var b in sampleBooks)
                    {
                        Console.WriteLine($" - {b}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving library information: {ex.Message}");
            }
        }
        public void UpdateLibrary()
        {
            try
            {
                Console.Write("Enter Library Id to update: ");
                string idInput = Console.ReadLine()?.Trim();

                if (!int.TryParse(idInput, out int libraryId) || libraryId <= 0)
                {
                    Console.WriteLine("Invalid Id. Please enter a positive numeric library Id.");
                    return;
                }

                var library = _libraryRepository.GetById(libraryId);
                if (library == null)
                {
                    Console.WriteLine($"Library with Id {libraryId} was not found.");
                    return;
                }

                Console.WriteLine($"Current Name   : {library.Name}");
                Console.WriteLine($"Current Address: {library.Address}");

                Console.Write("Enter new Name (press Enter to keep current): ");
                string newName = Console.ReadLine();
                Console.Write("Enter new Address (press Enter to keep current): ");
                string newAddress = Console.ReadLine();

                // Normalize inputs
                newName = newName?.Trim();
                newAddress = newAddress?.Trim();

                bool nameChanged = !string.IsNullOrEmpty(newName) && !string.Equals(newName, library.Name, StringComparison.Ordinal);
                bool addressChanged = !string.IsNullOrEmpty(newAddress) && !string.Equals(newAddress, library.Address, StringComparison.Ordinal);

                if (!nameChanged && !addressChanged)
                {
                    Console.WriteLine("No changes detected. Library was not updated.");
                    return;
                }

                if (nameChanged)
                {
                    library.Name = newName;
                }

                if (addressChanged)
                {
                    library.Address = newAddress;
                }

                // Persist changes
                _libraryRepository.Update(library);

                Console.WriteLine("Library updated successfully.");
                Console.WriteLine($"Id: {library.Id} | Name: {library.Name} | Address: {library.Address}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the library: {ex.Message}");
            }
        }
        public void DeleteLibrary()
        {
            try
            {
                Console.Write("Enter Library Id to delete: ");
                string input = Console.ReadLine()?.Trim();

                if (!int.TryParse(input, out int libraryId) || libraryId <= 0)
                {
                    Console.WriteLine("Invalid Id. Please enter a positive numeric library Id.");
                    return;
                }

                var library = _libraryRepository.GetById(libraryId);
                if (library == null)
                {
                    Console.WriteLine($"Library with Id {libraryId} was not found.");
                    return;
                }

                var books = (_bookRepository.GetAll() ?? Enumerable.Empty<Book>()).Where(b => b.LibraryId == libraryId).ToList();
                var employees = (_employeeRepository.GetAll() ?? Enumerable.Empty<Employee>()).Where(e => e.LibraryId == libraryId).ToList();
                var customers = (_customerRepository.GetAll() ?? Enumerable.Empty<Customer>()).Where(c => c.LibraryId == libraryId).ToList();

                Console.WriteLine("About to delete the following library:");
                Console.WriteLine($"Id: {library.Id} | Name: {library.Name} | Address: {library.Address}");
                Console.WriteLine($"Related counts -> Books: {books.Count} | Employees: {employees.Count} | Customers: {customers.Count}");

                string prompt;
                if (books.Any() || employees.Any() || customers.Any())
                {
                    Console.WriteLine("Warning: Deleting this library will also delete all related books, employees, and customers.");
                    prompt = "Type 'YES' to confirm deletion of the library and all related records: ";
                }
                else
                {
                    prompt = "Type 'YES' to confirm deletion of the library: ";
                }

                Console.Write(prompt);
                string confirm = Console.ReadLine()?.Trim();

                if (!string.Equals(confirm, "YES", StringComparison.Ordinal))
                {
                    Console.WriteLine("Deletion cancelled.");
                    return;
                }

                // Perform deletions. Note: repositories use separate DbContext instances, so this is not atomic.
                // Delete related books
                foreach (var book in books)
                {
                    try
                    {
                        _bookRepository.Delete(book.Id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to delete Book Id {book.Id}: {ex.Message}");
                    }
                }

                // Delete related employees
                foreach (var emp in employees)
                {
                    try
                    {
                        _employeeRepository.Delete(emp.Id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to delete Employee Id {emp.Id}: {ex.Message}");
                    }
                }

                // Delete related customers
                foreach (var cust in customers)
                {
                    try
                    {
                        _customerRepository.Delete(cust.Id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to delete Customer Id {cust.Id}: {ex.Message}");
                    }
                }

                // Finally delete the library
                _libraryRepository.Delete(libraryId);

                Console.WriteLine($"Library '{library.Name}' (Id: {library.Id}) and its related records were deleted (where deletions succeeded).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the library: {ex.Message}");
            }
        }
        public void GetAllLibraries()
        {
            try
            {
                var libraries = _libraryRepository.GetAll()?.ToList() ?? new List<Library>();
                if (!libraries.Any())
                {
                    Console.WriteLine("No libraries found.");
                    return;
                }
                Console.WriteLine("Libraries:");
                foreach (var lib in libraries)
                {
                    Console.WriteLine($"Id: {lib.Id} | Name: {lib.Name} | Address: {lib.Address} | CreatedAt: {lib.CreatedAt:yyyy-MM-dd HH:mm}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving libraries: {ex.Message}");
            }
        }


        public void AddEmployee()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine()?.Trim();
            Console.Write("Enter Employee Position: ");
            string position = Console.ReadLine()?.Trim();
            Console.Write("Enter Employee Salary: ");
            if (!double.TryParse(Console.ReadLine(), out double salary))
            {
                Console.WriteLine("Invalid salary input. Employee was not added.");
                return;
            }
            Console.Write("Enter Hire Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime hireDate))
            {
                Console.WriteLine("Invalid date input. Employee was not added.");
                return;
            }
            Console.Write("Enter Library Id: ");
            if (!int.TryParse(Console.ReadLine(), out int libraryId))
            {
                Console.WriteLine("Invalid library Id input. Employee was not added.");
                return;
            }
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(position))
            {
                Console.WriteLine("Name and position are required. Employee was not added.");
                return;
            }
            var employee = new Employee
            {
                Name = name,
                Position = position,
                Salary = salary,
                HireDate = hireDate,
                LibraryId = libraryId,
                CreatedAt = DateTime.Now
            };
            try
            {
                _employeeRepository.Add(employee);
                Console.WriteLine($"Employee '{employee.Name}' added successfully.");
                if (employee.Id > 0)
                {
                    Console.WriteLine($"Assigned Id: {employee.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the employee: {ex.Message}");
            }
        }
        public void GetEmployee()
        {

            try
            {
                Console.Write("Enter Employee Id to view details or press Enter to list all employees: ");
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    var employees = _employeeRepository.GetAll()?.ToList() ?? new List<Employee>();
                    if (!employees.Any())
                    {
                        Console.WriteLine("No employees found.");
                        return;
                    }

                    Console.WriteLine("Employees:");
                    foreach (var emp in employees)
                    {
                        string fullName = $"{emp.Name} {emp.Surname}".Trim();
                        var lib = _libraryRepository.GetById(emp.LibraryId);
                        string libName = lib?.Name ?? "N/A";
                        Console.WriteLine($"Id: {emp.Id} | Name: {fullName} | Position: {emp.Position} | Library: {libName} | HireDate: {emp.HireDate:yyyy-MM-dd}");
                    }

                    return;
                }

                if (!int.TryParse(input, out int employeeId) || employeeId <= 0)
                {
                    Console.WriteLine("Invalid Id. Please enter a positive numeric employee Id.");
                    return;
                }

                var employee = _employeeRepository.GetById(employeeId);
                if (employee == null)
                {
                    Console.WriteLine($"Employee with Id {employeeId} was not found.");
                    return;
                }

                Console.WriteLine("Employee Details:");
                Console.WriteLine($"Id         : {employee.Id}");
                Console.WriteLine($"Name       : {employee.Name}");
                Console.WriteLine($"Surname    : {employee.Surname}");
                // Age is a DateOnly; only show if it's not default
                if (employee.Age > DateOnly.MinValue)
                {
                    Console.WriteLine($"Age        : {employee.Age:yyyy-MM-dd}");
                }
                else
                {
                    Console.WriteLine("Age        : N/A");
                }
                Console.WriteLine($"Phone      : {employee.PhoneNumber}");
                Console.WriteLine($"Email      : {employee.Email}");
                Console.WriteLine($"Address    : {employee.Address}");
                Console.WriteLine($"Position   : {employee.Position}");
                Console.WriteLine($"Salary     : {employee.Salary}");
                Console.WriteLine($"HireDate   : {employee.HireDate:yyyy-MM-dd}");
                Console.WriteLine($"CreatedAt  : {employee.CreatedAt:yyyy-MM-dd HH:mm}");

                var library = _libraryRepository.GetById(employee.LibraryId);
                if (library != null)
                {
                    Console.WriteLine($"Library    : Id {library.Id} | {library.Name} | {library.Address}");
                }
                else
                {
                    Console.WriteLine("Library    : N/A");
                }

                // Related counts
                var allEmployees = _employeeRepository.GetAll() ?? Enumerable.Empty<Employee>();
                var allBooks = _bookRepository.GetAll() ?? Enumerable.Empty<Book>();
                int employeesInLibrary = allEmployees.Count(e => e.LibraryId == employee.LibraryId);
                int booksInLibrary = allBooks.Count(b => b.LibraryId == employee.LibraryId);

                Console.WriteLine($"Employees at Library: {employeesInLibrary} | Books at Library: {booksInLibrary}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving employee information: {ex.Message}");
            }
        }
        public void UpdateEmployee()
        {
            try
            {
                Console.Write("Enter Employee Id to update: ");
                string idInput = Console.ReadLine()?.Trim();

                if (!int.TryParse(idInput, out int employeeId) || employeeId <= 0)
                {
                    Console.WriteLine("Invalid Id. Please enter a positive numeric employee Id.");
                    return;
                }

                var employee = _employeeRepository.GetById(employeeId);
                if (employee == null)
                {
                    Console.WriteLine($"Employee with Id {employeeId} was not found.");
                    return;
                }

                // Show current values
                Console.WriteLine($"Current Name     : {employee.Name}");
                Console.WriteLine($"Current Surname  : {employee.Surname}");
                Console.WriteLine($"Current Age      : {(employee.Age > DateOnly.MinValue ? employee.Age.ToString("yyyy-MM-dd") : "N/A")}");
                Console.WriteLine($"Current Phone    : {employee.PhoneNumber}");
                Console.WriteLine($"Current Email    : {employee.Email}");
                Console.WriteLine($"Current Address  : {employee.Address}");
                Console.WriteLine($"Current Position : {employee.Position}");
                Console.WriteLine($"Current Salary   : {employee.Salary}");
                Console.WriteLine($"Current HireDate : {employee.HireDate:yyyy-MM-dd}");
                Console.WriteLine($"Current LibraryId: {employee.LibraryId}");

                // Prompt for new values (press Enter to keep current)
                Console.Write("Enter new Name (press Enter to keep current): ");
                string newName = Console.ReadLine()?.Trim();
                Console.Write("Enter new Surname (press Enter to keep current): ");
                string newSurname = Console.ReadLine()?.Trim();
                Console.Write("Enter new Age (yyyy-MM-dd) (press Enter to keep current): ");
                string newAgeInput = Console.ReadLine()?.Trim();
                Console.Write("Enter new Phone Number (press Enter to keep current): ");
                string newPhone = Console.ReadLine()?.Trim();
                Console.Write("Enter new Email (press Enter to keep current): ");
                string newEmail = Console.ReadLine()?.Trim();
                Console.Write("Enter new Address (press Enter to keep current): ");
                string newAddress = Console.ReadLine()?.Trim();
                Console.Write("Enter new Position (press Enter to keep current): ");
                string newPosition = Console.ReadLine()?.Trim();
                Console.Write("Enter new Salary (press Enter to keep current): ");
                string newSalaryInput = Console.ReadLine()?.Trim();
                Console.Write("Enter new Hire Date (yyyy-MM-dd) (press Enter to keep current): ");
                string newHireDateInput = Console.ReadLine()?.Trim();
                Console.Write("Enter new Library Id (press Enter to keep current): ");
                string newLibraryIdInput = Console.ReadLine()?.Trim();

                bool changed = false;

                // Name
                if (!string.IsNullOrEmpty(newName) && !string.Equals(newName, employee.Name, StringComparison.Ordinal))
                {
                    employee.Name = newName;
                    changed = true;
                }

                // Surname
                if (!string.IsNullOrEmpty(newSurname) && !string.Equals(newSurname, employee.Surname, StringComparison.Ordinal))
                {
                    employee.Surname = newSurname;
                    changed = true;
                }

                // Age (DateOnly)
                if (!string.IsNullOrEmpty(newAgeInput))
                {
                    if (DateOnly.TryParse(newAgeInput, out DateOnly parsedAge))
                    {
                        if (parsedAge != employee.Age)
                        {
                            employee.Age = parsedAge;
                            changed = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Age format. Expected yyyy-MM-dd. Employee was not updated.");
                        return;
                    }
                }

                // Phone
                if (!string.IsNullOrEmpty(newPhone) && !string.Equals(newPhone, employee.PhoneNumber, StringComparison.Ordinal))
                {
                    employee.PhoneNumber = newPhone;
                    changed = true;
                }

                // Email
                if (!string.IsNullOrEmpty(newEmail) && !string.Equals(newEmail, employee.Email, StringComparison.Ordinal))
                {
                    employee.Email = newEmail;
                    changed = true;
                }

                // Address
                if (!string.IsNullOrEmpty(newAddress) && !string.Equals(newAddress, employee.Address, StringComparison.Ordinal))
                {
                    employee.Address = newAddress;
                    changed = true;
                }

                // Position
                if (!string.IsNullOrEmpty(newPosition) && !string.Equals(newPosition, employee.Position, StringComparison.Ordinal))
                {
                    employee.Position = newPosition;
                    changed = true;
                }

                // Salary
                if (!string.IsNullOrEmpty(newSalaryInput))
                {
                    if (double.TryParse(newSalaryInput, out double parsedSalary))
                    {
                        if (parsedSalary != employee.Salary)
                        {
                            employee.Salary = parsedSalary;
                            changed = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid salary input. Employee was not updated.");
                        return;
                    }
                }

                // HireDate
                if (!string.IsNullOrEmpty(newHireDateInput))
                {
                    if (DateTime.TryParse(newHireDateInput, out DateTime parsedHireDate))
                    {
                        if (parsedHireDate.Date != employee.HireDate.Date)
                        {
                            employee.HireDate = parsedHireDate.Date;
                            changed = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid hire date input. Expected yyyy-MM-dd. Employee was not updated.");
                        return;
                    }
                }

                // LibraryId
                if (!string.IsNullOrEmpty(newLibraryIdInput))
                {
                    if (int.TryParse(newLibraryIdInput, out int parsedLibId) && parsedLibId > 0)
                    {
                        if (parsedLibId != employee.LibraryId)
                        {
                            // Optionally verify library exists
                            var lib = _libraryRepository.GetById(parsedLibId);
                            if (lib == null)
                            {
                                Console.WriteLine($"Library with Id {parsedLibId} was not found. Employee was not updated.");
                                return;
                            }

                            employee.LibraryId = parsedLibId;
                            changed = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Library Id input. Employee was not updated.");
                        return;
                    }
                }

                if (!changed)
                {
                    Console.WriteLine("No changes detected. Employee was not updated.");
                    return;
                }

                _employeeRepository.Update(employee);
                Console.WriteLine("Employee updated successfully.");
                Console.WriteLine($"Id: {employee.Id} | Name: {employee.Name} {employee.Surname} | Position: {employee.Position} | Salary: {employee.Salary}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the employee: {ex.Message}");
            }
        }
        public void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter Employee Id to delete: ");
                string input = Console.ReadLine()?.Trim();

                if (!int.TryParse(input, out int employeeId) || employeeId <= 0)
                {
                    Console.WriteLine("Invalid Id. Please enter a positive numeric employee Id.");
                    return;
                }

                var employee = _employeeRepository.GetById(employeeId);
                if (employee == null)
                {
                    Console.WriteLine($"Employee with Id {employeeId} was not found.");
                    return;
                }

                // Display summary of the employee
                string fullName = $"{employee.Name} {employee.Surname}".Trim();
                Console.WriteLine("About to delete the following employee:");
                Console.WriteLine($"Id        : {employee.Id}");
                Console.WriteLine($"Name      : {fullName}");
                Console.WriteLine($"Position  : {employee.Position}");
                Console.WriteLine($"Salary    : {employee.Salary}");
                Console.WriteLine($"HireDate  : {employee.HireDate:yyyy-MM-dd}");
                Console.WriteLine($"CreatedAt : {employee.CreatedAt:yyyy-MM-dd HH:mm}");

                var library = _libraryRepository.GetById(employee.LibraryId);
                if (library != null)
                {
                    Console.WriteLine($"Library   : Id {library.Id} | {library.Name} | {library.Address}");
                }
                else
                {
                    Console.WriteLine("Library   : N/A");
                }

                Console.Write("Type 'YES' to confirm deletion of the employee: ");
                string confirm = Console.ReadLine()?.Trim();

                if (!string.Equals(confirm, "YES", StringComparison.Ordinal))
                {
                    Console.WriteLine("Deletion cancelled.");
                    return;
                }

                try
                {
                    _employeeRepository.Delete(employeeId);
                    Console.WriteLine($"Employee '{fullName}' (Id: {employeeId}) was deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to delete Employee Id {employeeId}: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the employee: {ex.Message}");
            }
        }
        public void GetAllEmployees()
        {
            try
            {
                var employees = _employeeRepository.GetAll()?.ToList() ?? new List<Employee>();
                if (!employees.Any())
                {
                    Console.WriteLine("No libraries found.");
                    return;
                }
                Console.WriteLine("Libraries:");
                foreach (var lib in employees)
                {
                    Console.WriteLine($"Id: {lib.Id} | Name: {lib.Name} | Address: {lib.Address} | CreatedAt: {lib.CreatedAt:yyyy-MM-dd HH:mm}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving libraries: {ex.Message}");
            }
        }


        public void AddCustomer()
        {
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine()?.Trim();
            Console.Write("Enter Customer Email: ");
            string email = Console.ReadLine()?.Trim();
            Console.Write("Enter Customer Phone Number: ");
            string phoneNumber = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.WriteLine("Name, email, and phone number are required. Customer was not added.");
                return;
            }
            var customer = new Customer
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber,
                CreatedAt = DateTime.Now
            };
            try
            {
                _customerRepository.Add(customer);
                Console.WriteLine($"Customer '{customer.Name}' added successfully.");
                if (customer.Id > 0)
                {
                    Console.WriteLine($"Assigned Id: {customer.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the customer: {ex.Message}");
            }
        }
        //public void Get

        public void AddBook()
        {
            Console.Write("Enter Book Name: ");
            string name = Console.ReadLine()?.Trim();
            Console.Write("Enter Book Author: ");
            string author = Console.ReadLine()?.Trim();
            Console.Write("Enter Publication Year: ");
            string yearInput = Console.ReadLine()?.Trim();
            Console.Write("Enter Genre: ");
            string genre = Console.ReadLine()?.Trim();
            Console.Write("Enter Publisher: ");
            string publisher = Console.ReadLine()?.Trim();
            Console.Write("Enter Page Count: ");
            string pageCountInput = Console.ReadLine()?.Trim();
            Console.Write("Enter Language: ");
            string language = Console.ReadLine()?.Trim();
            Console.Write("Enter Library Id: ");
            string libraryIdInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine("Book name and author are required. Book was not added.");
                return;
            }

            if (!int.TryParse(yearInput, out int year))
            {
                Console.WriteLine("Invalid year input. Book was not added.");
                return;
            }

            if (!int.TryParse(pageCountInput, out int pageCount))
            {
                Console.WriteLine("Invalid page count input. Book was not added.");
                return;
            }

            if (!int.TryParse(libraryIdInput, out int libraryId))
            {
                Console.WriteLine("Invalid library Id input. Book was not added.");
                return;
            }

            if (year <= 0 || pageCount <= 0)
            {
                Console.WriteLine("Year and page count must be positive values. Book was not added.");
                return;
            }

            var book = new Book
            {
                Name = name,
                Author = author,
                Year = year,
                Genre = genre,
                Publisher = publisher,
                PageCount = pageCount,
                Language = language,
                LibraryId = libraryId,
                CreatedAt = DateTime.Now
            };

            try
            {
                _bookRepository.Add(book);
                Console.WriteLine($"Book '{book.Name}' by {book.Author} added successfully.");
                if (book.Id > 0)
                {
                    Console.WriteLine($"Assigned Id: {book.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the book: {ex.Message}");
            }
        }
    }

}
