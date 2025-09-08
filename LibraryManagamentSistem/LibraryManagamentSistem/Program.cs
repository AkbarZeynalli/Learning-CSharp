using LibraryManagamentSistem.Services;

namespace LibraryManagamentSistem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperationService operationManagement = new OperationService();
            int choise = 0;
            do
            {
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Add Library");
                Console.WriteLine("2. Add Employee");
                Console.WriteLine("3. Add Customer");
                Console.WriteLine("4. Add Book");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        operationManagement.AddLibrary();
                        break;
                    case 2:
                        operationManagement.AddEmployee();
                        break;
                    case 3:
                        operationManagement.AddCustomer();
                        break;
                    case 4:
                        operationManagement.AddBook();
                        break;
                }
            }
            while (choise != 5);

        }
    }
}
