using FoodWasteApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodWasteApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IReservationService _reservationService;

        public ReservationController(ILogger<ReservationController> logger, IReservationService reservationService)
        {
            _logger = logger;
            _reservationService = reservationService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var reservations = _reservationService.GetAll();

            var json = JsonConvert.SerializeObject(reservations, Newtonsoft.Json.Formatting.Indented);
            _logger.LogInformation("Retrieved all reservations.");
            return Ok(json);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BLL.Dtos.ReservationDto dto)
        {
            await _reservationService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BLL.Dtos.ReservationDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _reservationService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _reservationService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _reservationService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _reservationService.DeleteAsync(id);
            return NoContent();
        }

    }
}
