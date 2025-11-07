using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Models;
using TMS_ERD.Repository;
using TMS_ERD.Dtos;

namespace TMS_ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IGenericRepository<Participant> _participantRepository;

        public ParticipantsController(IGenericRepository<Participant> participantRepository)
        {
            _participantRepository = participantRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var participants = await _participantRepository.GetAllAsync();
            var dtoList = participants.Select(p => new ParticipantDto
            {
                Id = p.Id,
                TrainingId = p.TrainingId,
                EmployeeId = p.EmployeeId,
                Completed = p.Completed,
                CompletionPercentage = p.CompletionPercentage
            });
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var participant = await _participantRepository.GetByIdAsync(id);
            if (participant == null)
                return NotFound();

            var dto = new ParticipantDto
            {
                Id = participant.Id,
                TrainingId = participant.TrainingId,
                EmployeeId = participant.EmployeeId,
                Completed = participant.Completed,
                CompletionPercentage = participant.CompletionPercentage
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ParticipantDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var participant = new Participant
            {
                TrainingId = dto.TrainingId,
                EmployeeId = dto.EmployeeId,
                Completed = dto.Completed,
                CompletionPercentage = dto.CompletionPercentage
            };

            await _participantRepository.AddAsync(participant);
            return CreatedAtAction(nameof(GetById), new { id = participant.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ParticipantDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var existing = await _participantRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.TrainingId = dto.TrainingId;
            existing.EmployeeId = dto.EmployeeId;
            existing.Completed = dto.Completed;
            existing.CompletionPercentage = dto.CompletionPercentage;

            await _participantRepository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _participantRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _participantRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
