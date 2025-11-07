using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Models;
using TMS_ERD.Repository;
using TMS_ERD.Dtos;

namespace TMS_ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly IGenericRepository<Training> _trainingRepository;

        public TrainingsController(IGenericRepository<Training> trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        // GET: api/Trainings
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trainings = await _trainingRepository.GetAllAsync();

            var dtoList = trainings.Select(t => new TrainingDto
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                StartDate = t.StartDate,
                EndDate = t.EndDate
            });

            return Ok(dtoList);
        }

        // GET: api/Trainings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var training = await _trainingRepository.GetByIdAsync(id);
            if (training == null)
                return NotFound();

            var dto = new TrainingDto
            {
                Id = training.Id,
                Title = training.Title,
                Description = training.Description,
                StartDate = training.StartDate,
                EndDate = training.EndDate
            };

            return Ok(dto);
        }

        // POST: api/Trainings
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrainingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var training = new Training
            {
                Title = dto.Title,
                Description = dto.Description,
                Mode = dto.Mode,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TrainerId = dto.TrainerId                
            };

            await _trainingRepository.AddAsync(training);

            dto.Id = training.Id;
            return CreatedAtAction(nameof(GetById), new { id = training.Id }, dto);
        }

        // PUT: api/Trainings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TrainingDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var existing = await _trainingRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.StartDate = dto.StartDate;
            existing.EndDate = dto.EndDate;

            await _trainingRepository.UpdateAsync(existing);
            return NoContent();
        }

        // DELETE: api/Trainings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _trainingRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _trainingRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
