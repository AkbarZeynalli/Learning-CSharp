using LibraryGenericRepository.Services;
namespace LibraryManagamentSistem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OperationManagment operationManagment = new OperationManagment();
            int choise = 0;
            do
            {
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Library");
                Console.WriteLine("2. Employee");
                Console.WriteLine("3. Customer");
                Console.WriteLine("4. Book");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        LibraryMenu();
                        break;
                    case 2:
                        EmployeeMenu();
                        break;
                    case 3:
                        CustomerMenu();
                        break;
                    case 4:
                        BookMenu();
                        break;
                }
            }
            while (choise != 5);

        }

        static void LibraryMenu()
        {
            var operationManagment = new OperationManagment();
            int libraryChoice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Library Menu");
                Console.WriteLine("1. Add Library");
                Console.WriteLine("2. Get Library by ID");
                Console.WriteLine("3. Update Library");
                Console.WriteLine("4. Delete Library");
                Console.WriteLine("5. Get All Libraries");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out libraryChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (libraryChoice)
                {
                    case 1:
                        operationManagment.AddLibrary();
                        break;
                    case 2:
                        operationManagment.GetLibrary();
                        break;
                    case 3:
                        operationManagment.UpdateLibrary();
                        break;
                    case 4:
                        operationManagment.DeleteLibrary();
                        break;
                    case 5:
                        operationManagment.GetAllLibraries();
                        break;
                    case 6:
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (libraryChoice != 6);
        }

        static void EmployeeMenu()
        {
            var operationManagment = new OperationManagment();
            int employeeChoice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Employee Menu");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Get Employee by ID");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Get All Employees");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out employeeChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                switch (employeeChoice)
                {
                    case 1:
                        operationManagment.AddEmployee();
                        break;
                    case 2:
                        operationManagment.GetEmployee();
                        break;
                    case 3:
                        operationManagment.UpdateEmployee();
                        break;
                    case 4:
                        operationManagment.DeleteEmployee();
                        break;
                    case 5:
                        operationManagment.GetAllEmployees();
                        break;
                    case 6:
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (employeeChoice != 6);
        }

        static void CustomerMenu()
        {
            var operationManagment = new OperationManagment();
            int customerChoice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Customer Menu");
                Console.WriteLine("1. Add Customer");
                Console.WriteLine("2. Get Customer by ID");
                Console.WriteLine("3. Update Customer");
                Console.WriteLine("4. Delete Customer");
                Console.WriteLine("5. Get All Customers");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out customerChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (customerChoice)
                {
                    case 1:
                        operationManagment.AddCustomer();
                        break;
                    case 2:
                        operationManagment.GetCustomer();
                        break;
                    case 3:
                        operationManagment.UpdateCustomer();
                        break;
                    case 4:
                        operationManagment.DeleteCustomer();
                        break;
                    case 5:
                        operationManagment.GetAllCustomers();
                        break;
                    case 6:
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (customerChoice != 6);
        }

        static void BookMenu()
        {
            var operationManagment = new OperationManagment();
            int bookChoice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Book Menu");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Get Book by ID");
                Console.WriteLine("3. Update Book");
                Console.WriteLine("4. Delete Book");
                Console.WriteLine("5. Get All Books");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out bookChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (bookChoice)
                {
                    case 1:
                        operationManagment.AddBook();
                        break;
                    case 2:
                        operationManagment.GetBook();
                        break;
                    case 3:
                        operationManagment.UpdateBook();
                        break;
                    case 4:
                        operationManagment.DeleteBook();
                        break;
                    case 5:
                        operationManagment.GetAllBooks();
                        break;
                    case 6:
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (bookChoice != 6);
        }
    }
}
