using StudentManagmentSystem.Data;
using StudentManagmentSystem.Models;
using System;
using System.Linq;

namespace StudentManagmentSystem.Repositories
{
    internal class StudentRepository
    {
        private AppDbContext _context;

        public StudentRepository()
        {
            _context = new AppDbContext();
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            Console.WriteLine("Student added successfully.");
        }

        public void GetStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);

            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, DOB: {student.DOB}, Email: {student.Email}, Phone: {student.PhoneNumber}, Grade: {student.Grade}");
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = _context.Students.Find(student.Id);
            if (existingStudent == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            existingStudent.Name = student.Name;
            existingStudent.DOB = student.DOB;
            existingStudent.Email = student.Email;
            existingStudent.PhoneNumber = student.PhoneNumber;
            existingStudent.Grade = student.Grade;

            _context.SaveChanges();
            Console.WriteLine("Student updated successfully.");
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            Console.WriteLine("Student deleted successfully.");
        }

        public void GetAllStudents()
        {
            var students = _context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, DOB: {student.DOB}, Email: {student.Email}, Phone: {student.PhoneNumber}, Grade: {student.Grade}");
            }
        }
    }
}
