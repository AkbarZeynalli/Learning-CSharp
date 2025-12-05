using FMS.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryServices _countryServices;
        public CountryController(ILogger<CountryController> logger, ICountryServices countryServices)
        {
            _logger = logger;
            _countryServices = countryServices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var countries = _countryServices.GetAll();
            return Ok(countries);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await _countryServices.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Dtos.CountryDto dto)
        {
            await _countryServices.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Dtos.CountryDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _countryServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _countryServices.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _countryServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _countryServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
