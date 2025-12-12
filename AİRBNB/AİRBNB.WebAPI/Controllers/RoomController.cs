using AİRBNB.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AİRBNB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomService _roomService;

        public RoomController(ILogger<RoomController> logger, IRoomService roomService)
        {
            _logger = logger;
            _roomService = roomService;
        }
        // Implement CRUD operations for Student entity here  
        [HttpGet]
        public IActionResult GetAll()
        {
            var rooms = _roomService.GetAll();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BLL.Dtos.RoomDto dto)
        {
            await _roomService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BLL.Dtos.RoomDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _roomService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _roomService.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _roomService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _roomService.DeleteAsync(id);
            return NoContent();
        }







    }
}

