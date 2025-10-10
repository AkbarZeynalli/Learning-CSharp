using StudentManagmentSystem.Data;
using StudentManagmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSystem.Repositories
{
    internal class TeacherRepository
    {
        private AppDbContext _context;
        public TeacherRepository()
        {

            _context = new AppDbContext();
        }

        public void AddTeacher(Teacher teacher) {
        
            _context.Teachers.Add(teacher);
            _context.SaveChanges();

        }
        public void GetTeacher(int teacherId) {
        
            var teacher = _context.Teachers.Find(teacherId);
            Console.WriteLine($"ID: {teacher.Id}, Name: {teacher.Name}, DOB: {teacher.DOB}, Email: {teacher.Email}, Phone: {teacher.PhoneNumber}");

        }
        public void UpdateTeacher(Teacher teacher) {
        
        
            var existingTeacher = _context.Teachers.Find(teacher.Id);
            if (existingTeacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }
        public void DeleteTeacher(int teacherId) { 
        
            var teacher = _context.Teachers.Find(teacherId);
            if (teacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
        }
        public void GetAllTeachers() { 
        
            var teachers = _context.Teachers.ToList();
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.Id}, Name: {teacher.Name}, DOB: {teacher.DOB}, Email: {teacher.Email}, Phone: {teacher.PhoneNumber}");
            }

        }

    }
}
