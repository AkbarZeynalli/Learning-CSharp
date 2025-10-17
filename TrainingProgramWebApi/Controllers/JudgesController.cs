using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProgramWebApi.Dtos;
using TrainingProgramWebApi.Models;
using TrainingProgramWebApi.Repository;

namespace TrainingProgramWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgesController : ControllerBase
    {
        private readonly IGenericRepository<Judge> _judgeRepository;
        public JudgesController(IGenericRepository<Judge> judgeRepository)
        {
            _judgeRepository = judgeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllJudges()
        {
            var judges = await _judgeRepository.GetAllAsync();
            List<Judge> judgeDtos = new List<Judge>();
            foreach (var judge in judges)
            {
                Judge dto = new Judge
                {
                    Id = judge.GetHashCode(),
                    FullName = judge.FullName,
                    Email = judge.Email,
                    Specialization = judge.Specialization
                };
                judgeDtos.Add(dto);
            }
            return Ok(judgeDtos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJudgeById(int id)
        {
            var judge = await _judgeRepository.GetByIdAsync(id);
            if (judge == null)
            {
                return NotFound();
            }
            var dto = new JudgeDto
            {
                Id = judge.GetHashCode(),
                FullName = judge.FullName,
                Email = judge.Email,
                Specialization = judge.Specialization
            };
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateJudge([FromBody]  JudgeDto dto)
        {

            var judge = new Judge
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Specialization = dto.Specialization
            };
            await _judgeRepository.AddAsync(judge);
            return CreatedAtAction(nameof(GetJudgeById), new { id = judge.GetHashCode() }, judge);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJudge(int id, [FromBody] JudgeDto dto)
        {
            var judge = new Judge
            {
                Id = id,
                FullName = dto.FullName,
                Email = dto.Email,
                Specialization = dto.Specialization
            };
            if (id != judge.Id)
            {
                return BadRequest();
            }
            await _judgeRepository.UpdateAsync(judge);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJudge(int id)
        {
            var existingJudge = await _judgeRepository.GetByIdAsync(id);
            if (existingJudge == null)
            {
                return NotFound();
            }
            await _judgeRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
