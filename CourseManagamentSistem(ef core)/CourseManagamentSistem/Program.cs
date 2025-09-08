using CourseManagamentSistem.Services;

namespace CourseManagamentSistem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperationService operationService = new OperationService();
            int choice = 0;
            do
            {
                Console.WriteLine("Welcome to Course Management System");
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. Add Group");
                Console.WriteLine("3. Add Teacher");
                Console.WriteLine("4. Add Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        operationService.AddCourse();
                        break;
                    case 2:
                        operationService.AddGroup();
                        break;
                    case 3:
                        operationService.AddTeacher();
                        break;
                    case 4:
                        operationService.AddStudent();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            while (choice != 5);

        }
    }
}