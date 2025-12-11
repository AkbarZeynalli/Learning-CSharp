using FMS.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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

        // --- GET BY ID (Route Name Verildi — Çox Vacib) ---
        [HttpGet("{id}", Name = "GetPlayerById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var player = await _playerServices.GetByIdAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // --- ADD ---
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Dtos.PlayerDto dto)
        {
            try
            {
                var created = await _playerServices.AddAsync(dto);

                // CreatedAtAction FIXED
                return CreatedAtAction(
                    actionName: "GetPlayerById",
                    routeValues: new { id = created.Id },
                    value: created
                );
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // --- UPDATE ---
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


        // --- DELETE ---
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var exists = await _playerServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _playerServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
