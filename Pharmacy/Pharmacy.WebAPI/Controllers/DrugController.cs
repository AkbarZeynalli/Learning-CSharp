using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.BLL.Services.Interfaces;

namespace Pharmacy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : Controller
    {
        private readonly ILogger<DrugController> _logger;
        private readonly IDrugservice _drugservice;


        public DrugController(ILogger<DrugController> logger, IDrugservice drugservice)
        {
            _logger = logger;
            _drugservice = drugservice;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bookings = _drugservice.GetAll();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _drugservice.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BLL.Dtos.DrugDto dto)
        {
            await _drugservice.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BLL.Dtos.DrugDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _drugservice.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _drugservice.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _drugservice.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _drugservice.DeleteAsync(id);
            return NoContent();
        }




    }
}
