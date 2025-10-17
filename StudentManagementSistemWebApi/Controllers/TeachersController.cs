using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSistemWebApi.Dtos;
using StudentManagementSistemWebApi.Models;
using StudentManagementSistemWebApi.Repository;

namespace StudentManagementSistemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        // Implementation will go here
        private readonly IGenericRepository<Teacher> _teacherRepository;
        public TeachersController(IGenericRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            List<TeacherDto> teacherDtos = new List<TeacherDto>();
            foreach (var teacher in teachers)
            {
                var dto = new TeacherDto
                {
                    Name = teacher.Name,
                    DOB = teacher.DOB,
                    Email = teacher.Email,
                    PhoneNumber = teacher.PhoneNumber,
                    Subject = teacher.Subject
                };
                teacherDtos.Add(dto);
            }
            return Ok(teacherDtos);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherDto dto)
        {
            var teacher = new Teacher
            {
                Name = dto.Name,
                DOB = dto.DOB,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Subject = dto.Subject
            };
            await _teacherRepository.AddAsync(teacher);
            return CreatedAtAction(nameof(GetAllTeachers), new { id = teacher.Id }, teacher);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var dto = new TeacherDto
            {
                Name = teacher.Name,
                DOB = teacher.DOB,
                Email = teacher.Email,
                PhoneNumber = teacher.PhoneNumber,
                Subject = teacher.Subject
            };
            return Ok(dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] TeacherDto dto)
        {
            var teacher = new Teacher
            {
                Id = id,
                Name = dto.Name,
                DOB = dto.DOB,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Subject = dto.Subject
            };
            if (id != teacher.Id)
            {
                return BadRequest();
            }
            await _teacherRepository.UpdateAsync(teacher);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var existingTeacher = await _teacherRepository.GetByIdAsync(id);
            if (existingTeacher == null)
            {
                return NotFound();
            }
            await _teacherRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
