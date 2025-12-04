using Microsoft.AspNetCore.Mvc;
using UMSApp.WebAPI.Services.Interfaces;

namespace UMSApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {

        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        // Implement CRUD operations for Student entity here  

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] UMSApp.WebAPI.Dtos.StudentDto studentDto)
        {
            await _studentService.AddAsync(studentDto);
            return CreatedAtAction(nameof(GetStudentById), new { id = studentDto.Id }, studentDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UMSApp.WebAPI.Dtos.StudentDto studentDto)
        {
            if (id != studentDto.Id)
            {
                return BadRequest();
            }
            var exists = await _studentService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _studentService.UpdateAsync(studentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var exists = await _studentService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
