using FMS.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : Controller
    {
        private readonly ILogger<GoalController> _logger;
        private readonly IGoalServices _goalServices;

        public GoalController(ILogger<GoalController> logger, IGoalServices goalServices)
        {
            _logger = logger;
            _goalServices = goalServices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var goals = _goalServices.GetAll();
            return Ok(goals);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var goal = await _goalServices.GetByIdAsync(id);
            if (goal == null)
            {
                return NotFound();
            }
            return Ok(goal);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Dtos.GoalDto dto)
        {
            await _goalServices.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Dtos.GoalDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _goalServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _goalServices.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _goalServices.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _goalServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
