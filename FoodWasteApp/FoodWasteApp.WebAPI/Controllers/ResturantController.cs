using FoodWasteApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodWasteApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController : Controller
    {
        private readonly ILogger<ResturantController> _logger;
        private readonly IResturantService _resturantService;

        public ResturantController(ILogger<ResturantController> logger, IResturantService resturantService)
        {
            _logger = logger;
            _resturantService = resturantService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resturants = _resturantService.GetAll();
            var json = JsonConvert.SerializeObject(resturants, Newtonsoft.Json.Formatting.Indented);
            _logger.LogInformation("Retrieved all resturants.");
            return Ok(json);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resturant = await _resturantService.GetByIdAsync(id);
            if (resturant == null)
            {
                return NotFound();
            }
            return Ok(resturant);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BLL.Dtos.RestaurantDto dto)
        {
            await _resturantService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BLL.Dtos.RestaurantDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _resturantService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _resturantService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _resturantService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _resturantService.DeleteAsync(id);
            return NoContent();
        }

    }
}
