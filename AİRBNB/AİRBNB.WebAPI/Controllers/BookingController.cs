using AİRBNB.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AİRBNB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingService _bookingService;
        public BookingController(ILogger<BookingController> logger, IBookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }
        // Implement CRUD operations for Booking entity here  
        [HttpGet]
        public IActionResult GetAll()
        {
            var bookings = _bookingService.GetAll();
            return Ok(bookings);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BLL.Dtos.BookingDto dto)
        {
            await _bookingService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BLL.Dtos.BookingDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _bookingService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _bookingService.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _bookingService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _bookingService.DeleteAsync(id);
            return NoContent();
        }









    }
}
