namespace ClassApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperationManagement operationManagement = new OperationManagement();
            int choice = 0;
            do
            {
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Add Library");
                Console.WriteLine("2. Add Employee");
                Console.WriteLine("3. Add Customer");
                Console.WriteLine("4. Add Book");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Library Selected");
                        operationManagement.AddLibrary();
                        break;
                    case 2:
                        Console.WriteLine("Employe Selected");
                        operationManagement.AddEmployee();
                        break;
                    case 3:
                        Console.WriteLine("Customer Selected");
                        operationManagement.AddCustomer();
                        break;
                    case 4:
                        Console.WriteLine("Book Selected");
                        operationManagement.AddBook();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;

                }
            }
            while (choice != 5);

        }
    }


}
