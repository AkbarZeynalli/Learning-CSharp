using StudentManagmentSystem.Models;
using StudentManagmentSystem.Repositories;
using System;

namespace StudentManagmentSystem.Services
{
    internal class OperationManagment
    {
        private StudentRepository _studentRepo;
         private TeacherRepository _teacherRepo;
        private CourseRepository _courseRepo;


        public OperationManagment()
        {
            _studentRepo = new StudentRepository();
            _teacherRepo = new TeacherRepository();
            _courseRepo = new CourseRepository();
        }

        public void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
            DateTime dob;
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.Write("Invalid date. Try again (yyyy-MM-dd): ");
            }

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Grade: ");
            string grade = Console.ReadLine();

            var student = new Student
            {
                Name = name,
                DOB = dob,
                Email = email,
                PhoneNumber = phone,
                Grade = grade
            };

            _studentRepo.AddStudent(student);
        }

        public void GetStudent()
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _studentRepo.GetStudent(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void UpdateStudent()
        {
            Console.Write("Enter student ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Enter new Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new Date of Birth (yyyy-MM-dd): ");
            DateTime dob;
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.Write("Invalid date. Try again (yyyy-MM-dd): ");
            }

            Console.Write("Enter new Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter new Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter new Grade: ");
            string grade = Console.ReadLine();

            var student = new Student
            {
                Id = id,
                Name = name,
                DOB = dob,
                Email = email,
                PhoneNumber = phone,
                Grade = grade
            };

            _studentRepo.UpdateStudent(student);
        }

        public void DeleteStudent()
        {
            Console.Write("Enter student ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _studentRepo.DeleteStudent(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void GetAllStudents()
        {
            _studentRepo.GetAllStudents();
        }

        public void AddTeacher()
        {
            Console.Write("Enter teacher name: ");  
            string name = Console.ReadLine();
            Console.Write("Enter Subject: ");
            string subject = Console.ReadLine();
            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();
            var teacher = new Teacher
            {
                Name = name,
                Subject = subject,
                Email = email,
                PhoneNumber = phone
            };
            _teacherRepo.AddTeacher(teacher);
        }
        public void GetTeacher()
        {
            Console.Write("Enter teacher ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _teacherRepo.GetTeacher(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }

        }
        public void UpdateTeacher()
        {
            Console.Write("Enter teacher ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }
            Console.Write("Enter new Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new Subject: ");
            string subject = Console.ReadLine();
            Console.Write("Enter new Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter new Phone Number: ");
            string phone = Console.ReadLine();
            var teacher = new Teacher
            {
                Id = id,
                Name = name,
                Subject = subject,
                Email = email,
                PhoneNumber = phone
            };
            _teacherRepo.UpdateTeacher(teacher);
        }
        public void DeleteTeacher()
        {
            Console.Write("Enter teacher ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _teacherRepo.DeleteTeacher(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
        public void GetAllTeachers()
        {
            _teacherRepo.GetAllTeachers();
        }

        public void AddCourse()
        {
            Console.Write("Enter course name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Credits: ");
            if (!int.TryParse(Console.ReadLine(), out int credits))
            {
                Console.WriteLine("Invalid credits.");
                return;
            }
            var course = new Course
            {
                Name = name,
                Description = description,
                Credits = credits
            };
            _courseRepo.AddCourse(course);
        }

        public void GetCourse()
        {
            Console.Write("Enter course ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _courseRepo.GetCourse(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void UpdateCourse()
        {
            Console.Write("Enter course ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }
            Console.Write("Enter new Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter new Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter new Credits: ");
            if (!int.TryParse(Console.ReadLine(), out int credits))
            {
                Console.WriteLine("Invalid credits.");
                return;
            }
            var course = new Course
            {
                Id = id,
                Name = name,
                Description = description,
                Credits = credits
            };
            _courseRepo.UpdateCourse(course);
        }
        public void DeleteCourse()
        {
            Console.Write("Enter course ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _courseRepo.DeleteCourse(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        public void GetAllCourses()
        {
            _courseRepo.GetAllCourses();
        }
    }
}
