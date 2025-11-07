using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Dtos;
using TMS_ERD.Models;
using TMS_ERD.Repository;

namespace TMS_ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly IGenericRepository<Survey> _surveyRepository;

        public SurveysController(IGenericRepository<Survey> surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        // ✅ GET: api/Surveys
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var surveys = await _surveyRepository.GetAllAsync();

            var dtos = surveys.Select(s => new SurveyDto
            {
                Id = s.Id,
                TrainingId = s.TrainingId,
                Status = s.Status,
                OpenedAt = s.OpenedAt,
                ClosedAt = (DateTime)s.ClosedAt
            });

            return Ok(dtos);
        }

        // ✅ GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var survey = await _surveyRepository.GetByIdAsync(id);
            if (survey == null)
                return NotFound();

            var dto = new SurveyDto
            {
                Id = survey.Id,
                TrainingId = survey.TrainingId,
                Status = survey.Status,
                OpenedAt = survey.OpenedAt,
                ClosedAt = (DateTime)survey.ClosedAt
            };

            return Ok(dto);
        }

        // ✅ POST: api/Surveys
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SurveyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new Survey
            {
                TrainingId = dto.TrainingId,
                Status = dto.Status,
                OpenedAt = dto.OpenedAt,
                ClosedAt = dto.ClosedAt
            };

            await _surveyRepository.AddAsync(entity);

            // entity əlavə olunandan sonra ID avtomatik yaranır:
            dto.Id = entity.Id;

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
        }

        // ✅ PUT: api/Surveys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SurveyDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID uyğunsuzdur.");

            var existing = await _surveyRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.TrainingId = dto.TrainingId;
            existing.Status = dto.Status;
            existing.OpenedAt = dto.OpenedAt;
            existing.ClosedAt = dto.ClosedAt;

            await _surveyRepository.UpdateAsync(existing);
            return NoContent();
        }

        // ✅ DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _surveyRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _surveyRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
