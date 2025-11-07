using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Dtos;
using TMS_ERD.Models;
using TMS_ERD.Repository;

namespace TMS_ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainersController : ControllerBase
    {
        private readonly IGenericRepository<Trainer> _trainerRepository;

        public TrainersController(IGenericRepository<Trainer> trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        // GET: api/Trainers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainers = await _trainerRepository.GetAllAsync();
            var dtos = trainers.Select(t => new TrainerDto
            {
                Id = t.Id,
                Name = t.Name,
                Surname = t.Surname,
                Specialization = t.Specialization,
                Email = t.Email,
                IsActive = t.IsActive
            });
            return Ok(dtos);
        }

        // GET: api/Trainers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var trainer = await _trainerRepository.GetByIdAsync(id);
            if (trainer == null)
                return NotFound();

            var dto = new TrainerDto
            {
                Id = trainer.Id,
                Name = trainer.Name,
                Surname = trainer.Surname,
                Specialization = trainer.Specialization,
                Email = trainer.Email,
                IsActive = trainer.IsActive
            };
            return Ok(dto);
        }

        // POST: api/Trainers
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrainerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new Trainer
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Specialization = dto.Specialization,
                Email = dto.Email,
                IsActive = dto.IsActive
            };

            await _trainerRepository.AddAsync(entity);
            dto.Id = entity.Id;

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
        }

        // PUT: api/Trainers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TrainerDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var existing = await _trainerRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = dto.Name;
            existing.Surname = dto.Surname;
            existing.Specialization = dto.Specialization;
            existing.Email = dto.Email;
            existing.IsActive = dto.IsActive;

            await _trainerRepository.UpdateAsync(existing);
            return NoContent();
        }

        // DELETE: api/Trainers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _trainerRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _trainerRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
