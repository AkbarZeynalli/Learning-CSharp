using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Services;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carServices;

        public CarController(ICarService carServices)
        {
            _carServices = carServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetAll()
        {
            var books = await _carServices.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("by-model/{modelId}")]
        public async Task<ActionResult<List<CarDto>>> GetAllByModelId(int modelId)
        {
            var books = await _carServices.GetByModelId(modelId);
            return Ok(books);
        }

        [HttpGet("by-brand/{brandId}")]
        public async Task<ActionResult<List<CarDto>>> GetAllByBrandId(int brandId)
        {
            var books = await _carServices.GetByBrandId(brandId);
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetById(int id)
        {
            var customer = await _carServices.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CarDto dto)
        {
            await _carServices.AddAsync(dto);
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CarDto dto)
        {
            await _carServices.UpdateAsync(id, dto);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _carServices.DeleteAsync(id);
            return Ok();
        }
    }
}
