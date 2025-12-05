using FMS.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaugeController : Controller
    {
        private readonly ILogger<LeaugeController> _logger;
        private readonly ILeaugeServies _leaugeServies;

        public LeaugeController(ILogger<LeaugeController> logger, ILeaugeServies leaugeServies)
        {
            _logger = logger;
            _leaugeServies = leaugeServies;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var leauges = _leaugeServies.GetAll();
            return Ok(leauges);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leauge = await _leaugeServies.GetByIdAsync(id);
            if (leauge == null)
            {
                return NotFound();
            }
            return Ok(leauge);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Dtos.LeaugeDto dto)
        {
            await _leaugeServies.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Dtos.LeaugeDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _leaugeServies.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _leaugeServies.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _leaugeServies.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _leaugeServies.DeleteAsync(id);
            return NoContent();
        }
    }
}
