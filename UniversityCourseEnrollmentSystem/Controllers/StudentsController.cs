using Microsoft.AspNetCore.Mvc;
using UniversityCourseEnrollmentSystem.Models;
using UniversityCourseEnrollmentSystem.Repository;
using UniversityCourseEnrollmentSystem.Dtos;

namespace UniversityCourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IGenericRepository<Student> _studentRepository;

        public StudentsController(IGenericRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // 🔹 GET: api/Students
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetAllAsync();

            var studentDtos = students.Select(s => new StudentDto
            {
                Id = s.Id,
                FullName = s.FullName,
                Email = s.Email,
                EnrollmentDate = s.EnrollmentDate,
                DepartmentId = s.DepartmentId
            }).ToList();

            return Ok(studentDtos);
        }

        // 🔹 GET: api/Students/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
                return NotFound();

            var dto = new StudentDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email,
                EnrollmentDate = student.EnrollmentDate,
                DepartmentId = student.DepartmentId
            };

            return Ok(dto);
        }

        // 🔹 POST: api/Students
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto dto)
        {
            var student = new Student
            {
                FullName = dto.FullName,
                Email = dto.Email,
                EnrollmentDate = dto.EnrollmentDate,
                DepartmentId = dto.DepartmentId
            };

            await _studentRepository.AddAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        // 🔹 PUT: api/Students/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto dto)
        {
            var existing = await _studentRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.FullName = dto.FullName;
            existing.Email = dto.Email;
            existing.EnrollmentDate = dto.EnrollmentDate;
            existing.DepartmentId = dto.DepartmentId;

            await _studentRepository.UpdateAsync(existing);
            return NoContent();
        }

        // 🔹 DELETE: api/Students/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var existing = await _studentRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _studentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
