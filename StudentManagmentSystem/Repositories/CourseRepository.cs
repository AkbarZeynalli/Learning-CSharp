using StudentManagmentSystem.Data;
using StudentManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSystem.Repositories
{
    internal class CourseRepository
    {

        private AppDbContext _context;

        public CourseRepository()
        {
            _context = new AppDbContext();
        }
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
        public void GetCourse(int courseId)
        {
            var course = _context.Courses.Find(courseId);
            Console.WriteLine($"ID: {course.Id}, Name: {course.Name}, Description: {course.Description}, Credits: {course.Credits}");
        }
        public void UpdateCourse(Course course)
        {
            var existingCourse = _context.Courses.Find(course.Id);
            if (existingCourse == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
            _context.Courses.Update(course);
            _context.SaveChanges();
        }
        public void DeleteCourse(int courseId)
        {
            var course = _context.Courses.Find(courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
                return;
            }
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
        public void GetAllCourses()
        {
            var courses = _context.Courses.ToList();
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.Id}, Name: {course.Name}, Description: {course.Description}, Credits: {course.Credits}");
            }
        }


    }
}
