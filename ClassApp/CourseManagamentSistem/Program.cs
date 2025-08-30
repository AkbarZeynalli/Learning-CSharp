namespace CourseManagamentSistem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperationManagamentSistem operatingManagment = new OperationManagamentSistem();
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. Add Group");
                Console.WriteLine("3. Add Teacher");
                Console.WriteLine("4. Add Student");
                Console.WriteLine("5. Add Assignment");
                Console.WriteLine("6. Add Grade");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        operatingManagment.AddCourse();
                        break;
                    case 2:
                        operatingManagment.AddGroup();
                        break;
                    case 3:
                        operatingManagment.AddTeacher();
                        break;
                    case 4:
                        operatingManagment.AddStudent();
                        break;
                    case 5:
                        operatingManagment.AddAssignment();
                        break;
                    case 6:
                        operatingManagment.AddGrade();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 7);
        }
    }
}
