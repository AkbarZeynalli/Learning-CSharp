using FoodWasteApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodWasteApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : Controller
    {
        private readonly ILogger<FoodItemController> _logger;
        private readonly IFoodItemService _foodItemService;
        //private readonly ILogger<>

        public FoodItemController(ILogger<FoodItemController> logger, IFoodItemService foodItemService)
        {
            _logger = logger;
            _foodItemService = foodItemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var foodItems = _foodItemService.GetAll();
            // JSON-u beautify edirik
            var json = JsonConvert.SerializeObject(foodItems, Newtonsoft.Json.Formatting.Indented);

            //loglama
            _logger.LogInformation("Retrieved all food items.");
            return Ok(json);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var foodItem = await _foodItemService.GetByIdAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }
            return Ok(foodItem);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BLL.Dtos.FoodItemDto dto)
        {
            await _foodItemService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BLL.Dtos.FoodItemDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _foodItemService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _foodItemService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _foodItemService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _foodItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
