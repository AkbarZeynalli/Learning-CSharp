using Microsoft.AspNetCore.Mvc;
using UniversityCourseEnrollmentSystem.Models;
using UniversityCourseEnrollmentSystem.Repository;
using UniversityCourseEnrollmentSystem.Dtos;

namespace UniversityCourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IGenericRepository<Instructor> _instructorRepository;

        public InstructorsController(IGenericRepository<Instructor> instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        // 🔹 GET: api/Instructors
        [HttpGet]
        public async Task<IActionResult> GetAllInstructors()
        {
            var instructors = await _instructorRepository.GetAllAsync();

            var instructorDtos = instructors.Select(i => new InstructorDto
            {
                Id = i.Id,
                FullName = i.FullName,
                Email = i.Email,
                Office = i.Office,
                HireDate = i.HireDate,
                DepartmentId = i.DepartmentId
            }).ToList();

            return Ok(instructorDtos);
        }

        // 🔹 GET: api/Instructors/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorById(int id)
        {
            var instructor = await _instructorRepository.GetByIdAsync(id);
            if (instructor == null)
                return NotFound();

            var dto = new InstructorDto
            {
                Id = instructor.Id,
                FullName = instructor.FullName,
                Email = instructor.Email,
                Office = instructor.Office,
                HireDate = instructor.HireDate,
                DepartmentId = instructor.DepartmentId
            };

            return Ok(dto);
        }

        // 🔹 POST: api/Instructors
        [HttpPost]
        public async Task<IActionResult> CreateInstructor([FromBody] InstructorDto dto)
        {
            var instructor = new Instructor
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Office = dto.Office,
                HireDate = dto.HireDate,
                DepartmentId = dto.DepartmentId
            };

            await _instructorRepository.AddAsync(instructor);
            return CreatedAtAction(nameof(GetInstructorById), new { id = instructor.Id }, instructor);
        }

        // 🔹 PUT: api/Instructors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(int id, [FromBody] InstructorDto dto)
        {
            var existing = await _instructorRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.FullName = dto.FullName;
            existing.Email = dto.Email;
            existing.Office = dto.Office;
            existing.HireDate = dto.HireDate;
            existing.DepartmentId = dto.DepartmentId;

            await _instructorRepository.UpdateAsync(existing);
            return NoContent();
        }

        // 🔹 DELETE: api/Instructors/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var existing = await _instructorRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _instructorRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
