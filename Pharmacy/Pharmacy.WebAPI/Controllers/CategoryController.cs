using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmacy.BLL.Services.Interfaces;
using System.Xml;

namespace Pharmacy.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        //private readonly ILogger<CategoryController> _drugLogger;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAll();
            // JSON-u beautify edirik
            var json = JsonConvert.SerializeObject(categories, Newtonsoft.Json.Formatting.Indented);

            // Loglama  
            _logger.LogInformation("Retrieved categories:\n{JsonData}", json);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _categoryService.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BLL.Dtos.CategoryDto dto)
        {
            await _categoryService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BLL.Dtos.CategoryDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _categoryService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _categoryService.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _categoryService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }

    }
}
