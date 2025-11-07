using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Dtos;
using TMS_ERD.Models;
using TMS_ERD.Repository;

namespace TMS_ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTemplatesController : ControllerBase
    {
        private readonly IGenericRepository<QuestionTemplate> _questionTemplateRepository;

        public QuestionTemplatesController(IGenericRepository<QuestionTemplate> questionTemplateRepository)
        {
            _questionTemplateRepository = questionTemplateRepository;
        }

        // GET: api/QuestionTemplates
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var templates = await _questionTemplateRepository.GetAllAsync();

            var dtos = templates.Select(t => new QuestionTemplateDto
            {
                Id = t.Id,
                Text = t.Text,
                Type = t.Type,
                IsActive = t.IsActive,
                Options = t.Options
            });

            return Ok(dtos);
        }

        // GET: api/QuestionTemplates/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var template = await _questionTemplateRepository.GetByIdAsync(id);
            if (template == null)
                return NotFound();

            var dto = new QuestionTemplateDto
            {
                Id = template.Id,
                Text = template.Text,
                Type = template.Type,
                IsActive = template.IsActive,
                Options = template.Options
            };

            return Ok(dto);
        }

        // POST: api/QuestionTemplates
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionTemplateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new QuestionTemplate
            {
                Text = dto.Text,
                Type = dto.Type,
                IsActive = dto.IsActive,
                Options = dto.Options
            };

            await _questionTemplateRepository.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
        }

        // PUT: api/QuestionTemplates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] QuestionTemplateDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var existing = await _questionTemplateRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Text = dto.Text;
            existing.Type = dto.Type;
            existing.IsActive = dto.IsActive;
            existing.Options = dto.Options;

            await _questionTemplateRepository.UpdateAsync(existing);
            return NoContent();
        }

        // DELETE: api/QuestionTemplates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _questionTemplateRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _questionTemplateRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
