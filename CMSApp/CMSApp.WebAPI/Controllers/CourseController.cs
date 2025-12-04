using CMSApp.WebAPI.Dtos;
using CMSApp.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _courseService;

        public CourseController(ILogger<CourseController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = _courseService.GetAll();
            return Ok(courses);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _courseService.AddAsync(dto);
            return Ok();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse([FromBody] CourseDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _courseService.UpdateAsync(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var exists = await _courseService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _courseService.DeleteAsync(id);
            return Ok();


        }



    }
}
