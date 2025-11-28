using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Services;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : ControllerBase
    {
        private readonly ICarModelService _carModelService;

        public CarModelController(ICarModelService carModelService)
        {
            _carModelService = carModelService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarModelDto>>> GetAll()
        {
            var books = await _carModelService.GetAllAsync();
            return Ok(books);
        }
        [HttpGet("by-brand/{brandId}")]
        public async Task<ActionResult<IEnumerable<CarModelDto>>> GetByBrandId(int brandId)
        {
            var books = await _carModelService.GetByBrandId(brandId);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarModelDto>> GetById(int id)
        {
            var customer = await _carModelService.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CarModelDto dto)
        {
            await _carModelService.AddAsync(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CarModelDto dto)
        {
            await _carModelService.UpdateAsync(id, dto);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _carModelService.DeleteAsync(id);
            return Ok();
        }
    }
}
