using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Dtos;
using TMS_ERD.Models;
using TMS_ERD.Repository;

namespace TMS_ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveySubmissionsController : ControllerBase
    {
        private readonly IGenericRepository<SurveySubmission> _submissionRepository;

        public SurveySubmissionsController(IGenericRepository<SurveySubmission> submissionRepository)
        {
            _submissionRepository = submissionRepository;
        }

        // GET: api/SurveySubmissions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var submissions = await _submissionRepository.GetAllAsync();

            var dtos = submissions.Select(s => new SurveySubmissionDto
            {
                Id = s.Id,
                SurveyId = s.SurveyId,
                EmployeeId = s.EmployeeId,
                SubmittedAt = s.SubmittedAt,
                Feedback = null,  // modeldə bu property yoxdur, amma DTO-da optional saxlaya bilərsən
                Rating = null     // eyni şəkildə
            }).ToList();

            return Ok(dtos);
        }

        // GET: api/SurveySubmissions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var submission = await _submissionRepository.GetByIdAsync(id);
            if (submission == null)
                return NotFound();

            var dto = new SurveySubmissionDto
            {
                Id = submission.Id,
                SurveyId = submission.SurveyId,
                EmployeeId = submission.EmployeeId,
                SubmittedAt = submission.SubmittedAt,
                Feedback = null,
                Rating = null
            };

            return Ok(dto);
        }

        // POST: api/SurveySubmissions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SurveySubmissionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new SurveySubmission
            {
                SurveyId = dto.SurveyId,
                EmployeeId = dto.EmployeeId,
                SubmittedAt = dto.SubmittedAt == default ? DateTime.UtcNow : dto.SubmittedAt
            };

            await _submissionRepository.AddAsync(entity);
            dto.Id = entity.Id;

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
        }

        // PUT: api/SurveySubmissions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SurveySubmissionDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var existing = await _submissionRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.SurveyId = dto.SurveyId;
            existing.EmployeeId = dto.EmployeeId;
            existing.SubmittedAt = dto.SubmittedAt == default ? existing.SubmittedAt : dto.SubmittedAt;

            await _submissionRepository.UpdateAsync(existing);
            return NoContent();
        }

        // DELETE: api/SurveySubmissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _submissionRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _submissionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
