using FMS.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : Controller
    {
        private readonly ILogger<PositionController> _logger;
        private readonly IPositionServices _positionServices;
        public PositionController(ILogger<PositionController> logger, IPositionServices positionServices)
        {
            _logger = logger;
            _positionServices = positionServices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var positions = _positionServices.GetAll();
            return Ok(positions);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var position = await _positionServices.GetByIdAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return Ok(position);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Dtos.PositionDto dto)
        {
            await _positionServices.AddAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Dtos.PositionDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _positionServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _positionServices.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var exists = await _positionServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _positionServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
