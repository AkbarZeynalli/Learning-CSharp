using AİRBNB.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AİRBNB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _locationService;

        public LocationController(ILogger<LocationController> logger, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        // Implement CRUD operations for Student entity here  
        [HttpGet]
        public IActionResult GetAll()
        {
            var locations = _locationService.GetAll();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await _locationService.GetByIdAsync(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpPost] 
        public async Task<IActionResult> Add([FromBody] BLL.Dtos.LocationDto dto)
        {
            await _locationService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BLL.Dtos.LocationDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _locationService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _locationService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _locationService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _locationService.DeleteAsync(id);
            return NoContent();
        }



    }
}
