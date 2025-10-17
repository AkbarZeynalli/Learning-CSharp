using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSistemWebApi.Dtos;
using StudentManagementSistemWebApi.Models;
using StudentManagementSistemWebApi.Repository;

namespace StudentManagementSistemWebApi.Controllers
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
            List<CourseDto> courseDtos = new List<CourseDto>();
            foreach (var course in courses)
            {
                var dto = new CourseDto
                {
                    Name = course.Name,
                    Title = course.Title,
                    Description = course.Description,
                    Credits = course.Credits,
                    TeacherId = course.TeacherId
                };
                courseDtos.Add(dto);
            }
            return Ok(courseDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            var dto = new CourseDto
            {
                Name = course.Name,
                Title = course.Title,
                Description = course.Description,
                Credits = course.Credits,
                TeacherId = course.TeacherId
            };
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDto dto)
        {
            var course = new Course
            {
                Name = dto.Name,
                Title = dto.Title,
                Description = dto.Description,
                Credits = dto.Credits,
                TeacherId = dto.TeacherId
            };
            await _courseRepository.AddAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }
            await _courseRepository.UpdateAsync(course);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var existingCourse = await _courseRepository.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            await _courseRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
