using Microsoft.AspNetCore.Mvc;
using UniversityCourseEnrollmentSystem.Models;
using UniversityCourseEnrollmentSystem.Repository;
using UniversityCourseEnrollmentSystem.Dtos;

namespace UniversityCourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IGenericRepository<Course> _courseRepository;

        public CoursesController(IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllAsync();
            var dtos = courses.Select(c => new CourseDto
            {
                Id = c.Id,
                Title = c.Title,
                Code = c.Code,
                Credits = c.Credits,
                Description = c.Description,
                InstructorId = c.InstructorId,
                DepartmentId = c.DepartmentId,
                SemesterId = c.SemesterId
            }).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
                return NotFound();

            var dto = new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Code = course.Code,
                Credits = course.Credits,
                Description = course.Description,
                InstructorId = course.InstructorId,
                DepartmentId = course.DepartmentId,
                SemesterId = course.SemesterId
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDto dto)
        {
            var course = new Course
            {
                Title = dto.Title,
                Code = dto.Code,
                Credits = dto.Credits,
                Description = dto.Description,
                InstructorId = dto.InstructorId,
                DepartmentId = dto.DepartmentId,
                SemesterId = dto.SemesterId
            };

            await _courseRepository.AddAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDto dto)
        {
            var existing = await _courseRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Title = dto.Title;
            existing.Code = dto.Code;
            existing.Credits = dto.Credits;
            existing.Description = dto.Description;
            existing.InstructorId = dto.InstructorId;
            existing.DepartmentId = dto.DepartmentId;
            existing.SemesterId = dto.SemesterId;

            await _courseRepository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var existing = await _courseRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _courseRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
