using FMS.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerServices _playerServices;

        public PlayerController(ILogger<PlayerController> logger, IPlayerServices playerServices)
        {
            _logger = logger;
            _playerServices = playerServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var players = _playerServices.GetAll();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var player = await _playerServices.GetByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Dtos.PlayerDto dto)
        {
            await _playerServices.AddAsync(dto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Dtos.PlayerDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _playerServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _playerServices.UpdateAsync(dto);
            return NoContent();
        }










    }
}
