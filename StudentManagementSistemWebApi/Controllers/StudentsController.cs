using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSistemWebApi.Dtos;
using StudentManagementSistemWebApi.Models;
using StudentManagementSistemWebApi.Repository;

namespace StudentManagementSistemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // Implementation will go here
        private readonly IGenericRepository<Student> _studentRepository;
        public StudentsController(IGenericRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetAllAsync();

            List<StudentDto> studentDtos = new List<StudentDto>();
            foreach (var student in students) {  
                var dto = new StudentDto
                {
                    Name = student.Name,
                    DOB = student.DOB,
                    Email = student.Email,
                    PhoneNumber = student.PhoneNumber,
                    Grade = student.Grade
                };
                studentDtos.Add(dto);
            }
            return Ok(studentDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            var dto = new StudentDto
            {
                Name = student.Name,
                DOB = student.DOB,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Grade = student.Grade
            };
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDto sto)
        {
            var student = new Student
            {
                Name = sto.Name,
                DOB = sto.DOB,
                Email = sto.Email,
                PhoneNumber = sto.PhoneNumber,
                Grade = sto.Grade
            };
            await _studentRepository.AddAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDto sto)
        {
            var student = new Student
            {
                Id = id,
                Name = sto.Name,
                DOB = sto.DOB,
                Email = sto.Email,
                PhoneNumber = sto.PhoneNumber,
                Grade = sto.Grade
            };
            if (id != student.Id)
            {
                return BadRequest();
            }
            await _studentRepository.UpdateAsync(student);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
