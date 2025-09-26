using CourseManagementSoftware.SERVICES;
using System.Diagnostics;

namespace CourseManagementSoftware
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OperationService operationService = new OperationService();
            int choice;
            do
            {
                Console.WriteLine("Course Management Software");
                Console.WriteLine("1.Group management");
                Console.WriteLine("2.Teacher management");
                Console.WriteLine("3.Mentor management");
                Console.WriteLine("4.Student management");
                Console.WriteLine("5.Teacher - Group");
                Console.WriteLine("6.Mentor -Qrup");
                Console.WriteLine("7.Student - Group");
                Console.WriteLine("8.Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        operationService.AddGroup();
                        break;
                    case 2:
                        operationService.AddTeacher();
                        break;
                    case 3:
                        operationService.AddMentor();
                        break;
                    case 4:
                        operationService.AddStudent();
                        break;
                    case 5:
                        operationService.AssignTeacherToGroup();
                        break;
                    case 6:
                        operationService.AssignMentorToGroup();
                        break;
                    case 7:
                        operationService.AssignStudentToGroup();
                        break;
                }

            } while (choice != 8);
        }
    }
}
