using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UMSApp.WebAPI.Services.Interfaces;

namespace UMSApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly ILogger<UniversityController> _logger;
        private readonly IUniversityService _universityService;

        public UniversityController(ILogger<UniversityController> logger, IUniversityService universityService)
        {
            _logger = logger;
            _universityService = universityService;
        }


        [HttpGet]
        public IActionResult GetAllUniversities()
        {
            var universities = _universityService.GetAll();
            return Ok(universities);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUniversityById(int id)
        {
            var university = await _universityService.GetByIdAsync(id);
            if (university == null)
            {
                return NotFound();
            }
            return Ok(university);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUniversity([FromBody] UMSApp.WebAPI.Dtos.UniversityDto universityDto)
        {
            await _universityService.AddAsync(universityDto);
            return CreatedAtAction(nameof(GetUniversityById), new { id = universityDto.Id }, universityDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUniversity(int id, [FromBody] UMSApp.WebAPI.Dtos.UniversityDto universityDto)
        {
            if (id != universityDto.Id)
            {
                return BadRequest();
            }
            var exists = await _universityService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _universityService.UpdateAsync(universityDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            var exists = await _universityService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _universityService.DeleteAsync(id);
            return NoContent();
        }





    }
}
