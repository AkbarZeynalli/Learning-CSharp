using CourseManagamentSistem.Data;
using CourseManagamentSistem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentSistem.Services
{
    internal class OperationService
    {
        private AppDbContext appContext;

        public OperationService()
        {
            appContext = new AppDbContext();
        }

        public void AddCourse()
        {
            Course course = new Course();

            Console.Write("Enter Course Name: ");
            course.CourseName = Console.ReadLine();
            Console.Write("Enter Course Address: ");
            course.Address = Console.ReadLine();
            appContext.Courses.Add(course);
            appContext.SaveChanges();
        }

        public void AddGroup()
        {
            Group group = new Group();
            var courses = appContext.Courses.ToList();
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses available. Please add a course first.");
                return;
            }
            Console.WriteLine("Available Courses:");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Id}. {course.CourseName}");
            }
            Console.Write("Select Course by ID: ");
            int courseId = Convert.ToInt32(Console.ReadLine());
            group.CourseId = courseId;
            Console.Write("Enter Group Name: ");
            group.GroupName = Console.ReadLine();
            appContext.Groups.Add(group);
            appContext.SaveChanges();
        }

        public void AddTeacher()
        {
            Teacher teacher = new Teacher();
            var courses = appContext.Courses.ToList();
            if (courses.Count == 0)
            {
                Console.WriteLine("No courses available. Please add a course first.");
                return;
            }
            Console.WriteLine("Available Courses:");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Id}. {course.CourseName}");
            }
            Console.Write("Select Course by ID: ");
            int courseId = Convert.ToInt32(Console.ReadLine());
            teacher.CourseId = courseId;
            Console.Write("Enter Teacher Name: ");
            teacher.Name = Console.ReadLine();
            Console.Write("Enter Teacher Surname: ");
            teacher.Surname = Console.ReadLine();
            Console.Write("Enter Teacher Age (yyyy-MM-dd): ");
            teacher.Age = DateOnly.Parse(Console.ReadLine());
            Console.Write("Enter Teacher PhoneNumber: ");
            teacher.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Teacher Email: ");
            teacher.Email = Console.ReadLine();
            Console.Write("Enter Teacher Address: ");
            teacher.Address = Console.ReadLine();
            Console.Write("Enter Teacher Salary: ");
            teacher.Salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Teacher HireDate (yyyy-MM-dd): ");
            teacher.HireDate = DateOnly.Parse(Console.ReadLine());
            appContext.Teachers.Add(teacher);
            appContext.SaveChanges();
        }

        public void AddStudent()
        {
            Student student = new Student();
            var groups = appContext.Groups.ToList();
            if (groups.Count == 0)
            {
                Console.WriteLine("No groups available. Please add a group first.");
                return;
            }
            Console.WriteLine("Available Groups:");
            foreach (var group in groups)
            {
                Console.WriteLine($"{group.Id}. {group.GroupName}");
            }
            Console.Write("Select Group by ID: ");
            int groupId = Convert.ToInt32(Console.ReadLine());
            student.GroupId = groupId;
            Console.Write("Enter Student Name: ");
            student.Name = Console.ReadLine();
            Console.Write("Enter Student Surname: ");
            student.Surname = Console.ReadLine();
            Console.Write("Enter Student Age (yyyy-MM-dd): ");
            student.Age = DateOnly.Parse(Console.ReadLine());
            Console.Write("Enter Student PhoneNumber: ");
            student.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Student Email: ");
            student.Email = Console.ReadLine();
            Console.Write("Enter Student Address: ");
            student.Address = Console.ReadLine();
            appContext.Students.Add(student);
            appContext.SaveChanges();
        }

    }
}
