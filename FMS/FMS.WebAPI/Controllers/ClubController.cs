using FMS.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : Controller
    {
        private readonly ILogger<ClubController> _logger;
        private readonly IClubServices _clubServices;

        public ClubController(ILogger<ClubController> logger, IClubServices clubServices)
        {
            _logger = logger;
            _clubServices = clubServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var clubs = _clubServices.GetAll();
            return Ok(clubs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var club = await _clubServices.GetByIdAsync(id);
            if (club == null)
            {
                return NotFound();
            }
            return Ok(club);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Dtos.ClubDto dto)
        {
            await _clubServices.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Dtos.ClubDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _clubServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _clubServices.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _clubServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _clubServices.DeleteAsync(id);
            return NoContent();
        }






    }
}
