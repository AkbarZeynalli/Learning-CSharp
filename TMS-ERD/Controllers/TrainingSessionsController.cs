using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Models;
using TMS_ERD.Repository;
using TMS_ERD.Dtos;

namespace TMS_ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingSessionsController : ControllerBase
    {
        private readonly IGenericRepository<TrainingSession> _sessionRepository;

        public TrainingSessionsController(IGenericRepository<TrainingSession> sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        // GET: api/TrainingSessions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sessions = await _sessionRepository.GetAllAsync();
            var dtoList = sessions.Select(s => new TrainingSessionDto
            {
                Id = s.Id,
                TrainingId = s.TrainingId,
                SessionNumber = s.SessionNumber,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                Location = s.Location
            });

            return Ok(dtoList);
        }

        // GET: api/TrainingSessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var session = await _sessionRepository.GetByIdAsync(id);
            if (session == null)
                return NotFound();

            var dto = new TrainingSessionDto
            {
                Id = session.Id,
                TrainingId = session.TrainingId,
                SessionNumber = session.SessionNumber,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                Location = session.Location
            };

            return Ok(dto);
        }

        // POST: api/TrainingSessions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrainingSessionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var session = new TrainingSession
            {
                TrainingId = dto.TrainingId,
                SessionNumber = dto.SessionNumber,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Location = dto.Location
            };

            await _sessionRepository.AddAsync(session);
            dto.Id = session.Id;

            return CreatedAtAction(nameof(GetById), new { id = session.Id }, dto);
        }

        // PUT: api/TrainingSessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TrainingSessionDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var existing = await _sessionRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.TrainingId = dto.TrainingId;
            existing.SessionNumber = dto.SessionNumber;
            existing.StartTime = dto.StartTime;
            existing.EndTime = dto.EndTime;
            existing.Location = dto.Location;

            await _sessionRepository.UpdateAsync(existing);
            return NoContent();
        }

        // DELETE: api/TrainingSessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _sessionRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _sessionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
