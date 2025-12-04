using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMSApp.WebAPI.Services.Interfaces;

namespace UMSApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> _logger;
        private readonly ITeacherService _teacherService;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        // Implement CRUD operations for Teacher entity here    

        [HttpGet]
       
        public IActionResult GetAllTeachers()
        {
            var teachers = _teacherService.GetAll();
            return Ok(teachers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] UMSApp.WebAPI.Dtos.TeacherDto teacherDto)
        {
            await _teacherService.AddAsync(teacherDto);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacherDto.Id }, teacherDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] UMSApp.WebAPI.Dtos.TeacherDto teacherDto)
        {
            if (id != teacherDto.Id)
            {
                return BadRequest();
            }
            var exists = await _teacherService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _teacherService.UpdateAsync(teacherDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var exists = await _teacherService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _teacherService.DeleteAsync(id);
            return NoContent();
        }

    }
}
