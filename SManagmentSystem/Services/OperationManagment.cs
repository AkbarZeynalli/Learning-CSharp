using SManagmentSystem.Models;
using SManagmentSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SManagmentSystem.Services
{
    internal class OperationManagment
    {
        private GenericRepository<Student> _studentRepo;
        private GenericRepository<Course> _courseRepo;
        private GenericRepository<Teacher> _teacherRepo;
        private GenericRepository<Topic> _topicRepo;

        public OperationManagment()
        {
            _studentRepo = new GenericRepository<Student>();
            _courseRepo = new GenericRepository<Course>();
            _teacherRepo = new GenericRepository<Teacher>();
            _topicRepo = new GenericRepository<Topic>();
        }
        public void AddStudent()
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
            // List teachers and prompt for selection
            var teachers = _teacherRepo.GetAll();
            Console.WriteLine("Select Teacher by Id:");
            foreach (var teacher in teachers)
                Console.WriteLine($"{teacher.Id}: {teacher.Subject}");
            if (!int.TryParse(Console.ReadLine(), out int teacherId))
            {
                Console.WriteLine("Invalid teacher id.");
                return;
            }
            var course = new Course
            {
                Name = name,
                Description = description,
                Credits = credits,
                TeacherId = teacherId
            };
            _courseRepo.Add(course);
        }
        public void GetStudent()
        {
            Console.Write("Enter student ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _studentRepo.GetById(id);
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

            _studentRepo.Update(student);
        }
        public void DeleteStudent()
        {
            Console.Write("Enter student ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _studentRepo.Delete(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
        public void GetAllStudents()
        {
            _studentRepo.GetAll();
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
            _teacherRepo.Add(teacher);
        }
        public void GetTeacher()
        {
            Console.Write("Enter teacher ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _teacherRepo.GetById(id);
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
            _teacherRepo.Update(teacher);
        }
        public void DeleteTeacher()
        {
            Console.Write("Enter teacher ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _teacherRepo.Delete(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
        public void GetAllTeachers()
        {
            _teacherRepo.GetAll();
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
            // List teachers and prompt for selection
            var teachers = _teacherRepo.GetAll();
            Console.WriteLine("Select Teacher by Id:");
            foreach (var teacher in teachers)
                Console.WriteLine($"{teacher.Id}: {teacher.Subject}");
            if (!int.TryParse(Console.ReadLine(), out int teacherId))
            {
                Console.WriteLine("Invalid teacher id.");
                return;
            }
            var course = new Course
            {
                Name = name,
                Description = description,
                Credits = credits,
                TeacherId = teacherId
            };
            _courseRepo.Add(course);
        }
        public void GetCourse()
        {
            Console.Write("Enter course ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _courseRepo.GetById(id);
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
            _courseRepo.Update(course);
        }
        public void DeleteCourse()
        {
            Console.Write("Enter course ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _courseRepo.Delete(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
        public void GetAllCourses()
        {
            _courseRepo.GetAll();
        }


        public void AddTopic()
        {
            Console.Write("Enter Topic Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Topic Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.WriteLine("Invalid Course ID.");
                return;
            }

            var topic = new Topic
            {
                Title = title,
                Description = description,
                CourseId = courseId
            };

            _topicRepo.Add(topic);
        }
        public void GetTopic()
        {
            Console.Write("Enter Topic ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _topicRepo.GetById(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
        public void UpdateTopic()
        {
            Console.Write("Enter Topic ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Enter new Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter new Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter new Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.WriteLine("Invalid Course ID.");
                return;
            }

            var topic = new Topic
            {
                Id = id,
                Title = title,
                Description = description,
                CourseId = courseId
            };

            _topicRepo.Update(topic);
        }
        public void DeleteTopic()
        {
            Console.Write("Enter Topic ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _topicRepo.Delete(id);
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }
        public void GetAllTopics()
        {
            _topicRepo.GetAll();
        }

    }
}
