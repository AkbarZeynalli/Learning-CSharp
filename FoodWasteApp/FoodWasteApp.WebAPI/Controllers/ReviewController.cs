using FoodWasteApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodWasteApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewService _reviewService;

        public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService)
        {
            _logger = logger;
            _reviewService = reviewService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reviews = _reviewService.GetAll();
            var json = JsonConvert.SerializeObject(reviews, Newtonsoft.Json.Formatting.Indented);

            _logger.LogInformation("Retrieved all reviews.");
            return Ok(json);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var review = await _reviewService.GetByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BLL.Dtos.ReviewDto dto)
        {
            await _reviewService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BLL.Dtos.ReviewDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _reviewService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _reviewService.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _reviewService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _reviewService.DeleteAsync(id);
            return NoContent();
        }







    }
}
