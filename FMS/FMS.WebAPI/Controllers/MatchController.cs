using FMS.WebAPI.Dtos;
using FMS.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly ILogger<MatchController> _logger;
        private readonly IMatchServices _matchServices;

        public MatchController(ILogger<MatchController> logger, IMatchServices matchServices)
        {
            _logger = logger;
            _matchServices = matchServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var matches = _matchServices.GetAll();
            return Ok(matches);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var match = await _matchServices.GetByIdAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MatchDto dto)
        {
            await _matchServices.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MatchDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _matchServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _matchServices.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _matchServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _matchServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
