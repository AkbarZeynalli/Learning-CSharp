using FoodWasteApp.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodWasteApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var json = JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            _logger.LogInformation("Retrieved all users.");
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BLL.Dtos.UserDto dto)
        {
            await _userService.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BLL.Dtos.UserDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var exists = await _userService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _userService.UpdateAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exists = await _userService.Exists(id);
            if (!exists)
            {
                return NotFound();
            }
            await _userService.DeleteAsync(id);
            return NoContent();
        }

    }
}
