using Microsoft.AspNetCore.Mvc;
using TrainingProgramWebApi.Dtos;
using TrainingProgramWebApi.Models;
using TrainingProgramWebApi.Repository;

namespace TrainingProgramWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public TeachersController(IGenericRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherRepository.GetAllAsync();

            var teacherDtos = teachers.Select(t => new TeacherDto
            {
                Id = t.Id,
                FullName = t.FullName,
                Email = t.Email,
                Expertise = t.Expertise
            }).ToList();

            return Ok(teacherDtos);
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
                Id = teacher.Id,
                FullName = teacher.FullName,
                Email = teacher.Email,
                Expertise = teacher.Expertise
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherDto dto)
        {
            var teacher = new Teacher
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Expertise = dto.Expertise
            };

            await _teacherRepository.AddAsync(teacher);

            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.Id }, teacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] TeacherDto dto)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

            teacher.FullName = dto.FullName;
            teacher.Email = dto.Email;
            teacher.Expertise = dto.Expertise;

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
