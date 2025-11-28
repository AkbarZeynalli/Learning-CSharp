using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAll()
        {
            var books = await _brandService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDto>> GetById(int id)
        {
            var customer = await _brandService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Create(BrandDto dto)
        {
            await _brandService.AddAsync(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, BrandDto dto)
        {
            await _brandService.UpdateAsync(id, dto);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _brandService.DeleteAsync(id);
            return Ok();
        }
    }
}
