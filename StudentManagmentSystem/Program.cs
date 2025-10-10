using StudentManagmentSystem.Services;
using System;

namespace StudentManagmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Course");
                Console.WriteLine("3. Teacher");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        StudentMenu();
                        break;
                    case 2:
                        CourseMenu();
                        Console.WriteLine("Course menu not implemented yet.");
                        break;
                    case 3:
                        TeacherMenu();
                        Console.WriteLine("Teacher menu not implemented yet.");
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 4);
        }

        static void StudentMenu()
        {
            var operationManagment = new OperationManagment();
            int studentChoice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Student Menu");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Get Student by ID");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Get All Students");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out studentChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (studentChoice)
                {
                    case 1:
                        operationManagment.AddStudent();
                        break;
                    case 2:
                        operationManagment.GetStudent();
                        break;
                    case 3:
                        operationManagment.UpdateStudent();
                        break;
                    case 4:
                        operationManagment.DeleteStudent();
                        break;
                    case 5:
                        operationManagment.GetAllStudents();
                        break;
                    case 6:
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (studentChoice != 6);
        }

        static void TeacherMenu()
        {
            var operationManagment = new OperationManagment();
            int teacherChoice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Teacher Menu");
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Get Teacher by ID");
                Console.WriteLine("3. Update Teacher");
                Console.WriteLine("4. Delete Teacher");
                Console.WriteLine("5. Get All Teachers");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out teacherChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                switch (teacherChoice)
                {
                    case 1:
                        operationManagment.AddTeacher();
                        break;
                    case 2:
                        operationManagment.GetTeacher();
                        break;
                    case 3:
                        operationManagment.UpdateTeacher();
                        break;
                    case 4:
                        operationManagment.DeleteTeacher();
                        break;
                    case 5:
                        operationManagment.GetAllTeachers();
                        break;
                    case 6:
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (teacherChoice != 6);
        }

        static void CourseMenu()
        {
            var operationManagment = new OperationManagment();
            int courseChoice;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Course Menu");
                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. Get Course by ID");
                Console.WriteLine("3. Update Course");
                Console.WriteLine("4. Delete Course");
                Console.WriteLine("5. Get All Courses");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out courseChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                switch (courseChoice)
                {
                    case 1:
                        operationManagment.AddCourse();
                        break;
                    case 2:
                        operationManagment.GetCourse();
                        break;
                    case 3:
                        operationManagment.UpdateCourse();
                        break;
                    case 4:
                        operationManagment.DeleteCourse();
                        break;
                    case 5:
                        operationManagment.GetAllCourses();
                        break;
                    case 6:
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (courseChoice != 6);
        }
    }
}
