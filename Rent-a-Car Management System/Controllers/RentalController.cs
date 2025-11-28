using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Services;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalDto>>> GetAll()
        {
            var books = await _rentalService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentalDto>> GetById(int id)
        {
            var customer = await _rentalService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Create(RentalDto dto)
        {
            await _rentalService.AddAsync(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, RentalDto dto)
        {
            await _rentalService.UpdateAsync(id, dto);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _rentalService.DeleteAsync(id);
            return Ok();
        }
    }
}
