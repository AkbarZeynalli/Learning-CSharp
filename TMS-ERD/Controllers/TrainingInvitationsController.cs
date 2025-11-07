using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Dtos;
using TMS_ERD.Models;
using TMS_ERD.Repository;

namespace TMS_ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingInvitationsController : ControllerBase
    {
        private readonly IGenericRepository<TrainingInvitation> _invitationRepository;

        public TrainingInvitationsController(IGenericRepository<TrainingInvitation> invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }

        // GET: api/TrainingInvitations
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invitations = await _invitationRepository.GetAllAsync();

            var dtos = invitations.Select(i => new TrainingInvitationDto
            {
                Id = i.Id,
                TrainingId = i.TrainingId,
                EmployeeId = i.EmployeeId,
                SentAt = i.SentAt,
                Message = i.Message,
                Response = i.Response,
                EmployeeName = i.Employee?.Name, // Əgər Employee-də Surname varsa: $"{i.Employee.Name} {i.Employee.Surname}"
                TrainingTitle = i.Training?.Title
            });

            return Ok(dtos);
        }

        // GET: api/TrainingInvitations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var invitation = await _invitationRepository.GetByIdAsync(id);
            if (invitation == null)
                return NotFound();

            var dto = new TrainingInvitationDto
            {
                Id = invitation.Id,
                TrainingId = invitation.TrainingId,
                EmployeeId = invitation.EmployeeId,
                SentAt = invitation.SentAt,
                Message = invitation.Message,
                Response = invitation.Response,
                EmployeeName = invitation.Employee?.Name,
                TrainingTitle = invitation.Training?.Title
            };

            return Ok(dto);
        }

        // POST: api/TrainingInvitations
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrainingInvitationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new TrainingInvitation
            {
                TrainingId = dto.TrainingId,
                EmployeeId = dto.EmployeeId,
                SentAt = dto.SentAt,
                Message = dto.Message,
                Response = dto.Response
            };

            await _invitationRepository.AddAsync(entity);
            dto.Id = entity.Id;

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
        }

        // PUT: api/TrainingInvitations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TrainingInvitationDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var existing = await _invitationRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.TrainingId = dto.TrainingId;
            existing.EmployeeId = dto.EmployeeId;
            existing.SentAt = dto.SentAt;
            existing.Message = dto.Message;
            existing.Response = dto.Response;

            await _invitationRepository.UpdateAsync(existing);
            return NoContent();
        }

        // DELETE: api/TrainingInvitations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _invitationRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _invitationRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
