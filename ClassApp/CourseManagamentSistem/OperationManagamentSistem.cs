using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagamentSistem
{
    internal class OperationManagamentSistem
    {
        Store store = new Store();

        public void AddCourse()
        {
            Course course = new Course();
            Console.Write("Enter Course Name: ");
            course.CourseName = Console.ReadLine();
            Console.Write("Enter Course Address: ");
            course.Address = Console.ReadLine();
            course.CourseId = store.CourseList.Count + 1;
            store.CourseList.Add(course);
            Console.WriteLine("Course added successfully.");
        }

        public void AddGroup()
        {
            foreach (var item in store.CourseList)
            {
                Console.WriteLine($"Id: {item.CourseId} Name: {item.CourseName}");
            }
            Console.Write("Select Course by Id: ");
            int courseId = int.Parse(Console.ReadLine());
            Group group = new Group();
            Console.Write("Enter Group Name: ");
            group.GroupName = Console.ReadLine();
            group.GroupId = store.GroupList.Count + 1;
            store.GroupList.Add(group);
            Console.WriteLine("Group added successfully.");
        }
        public void AddTeacher()
        {

            foreach (var item in store.GroupList)
            {
                Console.WriteLine($"Id: {item.GroupId} Name: {item.GroupName}");
            }
            Console.Write("Select Course by Id: ");
            int courseId = int.Parse(Console.ReadLine());

            Teacher teacher = new Teacher();
            Console.Write("Enter Teacher Name: ");
            teacher.Name = Console.ReadLine();
            Console.Write("Enter Teacher Surname: ");
            teacher.Surname = Console.ReadLine();
            Console.Write("Enter Teacher Age (yyyy-MM-dd): ");
            teacher.Age = DateOnly.Parse(Console.ReadLine());
            Console.Write("Enter Teacher Salary: ");
            teacher.Salary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Teacher Phone Number: ");
            teacher.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Teacher Email: ");
            teacher.Email = Console.ReadLine();
            Console.Write("Enter Teacher Address: ");
            teacher.Address = Console.ReadLine();
            Console.Write("Enter Teacher Hire Date (yyyy-MM-dd): ");
            teacher.HireDate = DateTime.Parse(Console.ReadLine());
            teacher.TeacherId = store.TeacherList.Count + 1;
            store.TeacherList.Add(teacher);
            Console.WriteLine("Teacher added successfully.");
        }

        public void AddStudent()
        {
            foreach (var item in store.GroupList)
            {
                Console.WriteLine($"Id: {item.GroupId} Name: {item.GroupName}");
            }
            Console.Write("Select Course by Id: ");
            int courseId = int.Parse(Console.ReadLine());
            Student student = new Student();
            Console.Write("Enter Student Name: ");
            student.Name = Console.ReadLine();
            Console.Write("Enter Student Surname: ");
            student.Surname = Console.ReadLine();
            Console.Write("Enter Student Age (yyyy-MM-dd): ");
            student.Age = DateOnly.Parse(Console.ReadLine());
            Console.Write("Enter Student Phone Number: ");
            student.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Student Email: ");
            student.Email = Console.ReadLine();
            Console.Write("Enter Student Address: ");
            student.Address = Console.ReadLine();
            student.EnrollmentDate = DateTime.Now;
            student.StudentId = store.StudentList.Count + 1;
            store.StudentList.Add(student);
            Console.WriteLine("Student added successfully.");
        }

        public void AddAssignment()
        {
            foreach (var item in store.CourseList)
            {
                Console.WriteLine($"Id: {item.CourseId} Name: {item.CourseName}");
            }
            Console.Write("Select Course by Id: ");
            int courseId = int.Parse(Console.ReadLine());
            Assignment assignment = new Assignment();
            Console.Write("Enter Assignment Title: ");
            assignment.Title = Console.ReadLine();
            Console.Write("Enter Assignment Description: ");
            assignment.Description = Console.ReadLine();
            Console.Write("Enter Assignment Due Date (yyyy-MM-dd): ");
            assignment.DueDate = DateTime.Parse(Console.ReadLine());
            assignment.AssignmentId = store.AssignmentList.Count + 1;
            store.AssignmentList.Add(assignment);
            Console.WriteLine("Assignment added successfully.");
        }

        public void AddGrade()
        {
            foreach (var item in store.CourseList)
            {
                Console.WriteLine($"Id: {item.CourseId} Name: {item.CourseName}");
            }
            Console.Write("Select Course by Id: ");
            int courseId = int.Parse(Console.ReadLine());
            foreach (var item in store.StudentList)
            {
                Console.WriteLine($"Id: {item.StudentId} Name: {item.Name} Surname: {item.Surname}");
            }
            Console.Write("Select Student by Id: ");
            int studentId = int.Parse(Console.ReadLine());
            foreach (var item in store.AssignmentList)
            {
                Console.WriteLine($"Id: {item.AssignmentId} Title: {item.Title}");
            }
            Console.Write("Select Assignment by Id: ");
            int assignmentId = int.Parse(Console.ReadLine());
            Grade grade = new Grade();
            Console.Write("Enter Grade Score: ");
            grade.Score = Convert.ToDouble(Console.ReadLine());
            grade.GradeId = store.GradeList.Count + 1;
            store.GradeList.Add(grade);
        }
    }
}