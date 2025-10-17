using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProgramWebApi.Dtos;
using TrainingProgramWebApi.Models;
using TrainingProgramWebApi.Repository;

namespace TrainingProgramWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly IGenericRepository<Training> _traninRepo;
        public TrainingsController(IGenericRepository<Training> traninRepo)
        {
            _traninRepo = traninRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTrainings()
        {
            var trainings = await _traninRepo.GetAllAsync();
            List<Training> trainingDtos = new List<Training>();
            foreach (var training in trainings)
            {
                Training dto = new Training
                {
                    Id = training.Id,
                    Title = training.Title,
                    Description = training.Description,
                    Date = training.Date
                };
                trainingDtos.Add(dto);
            }
            return Ok(trainingDtos);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingById(int id)
        {
            var training = await _traninRepo.GetByIdAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            var dto = new Training
            {
                Id = training.Id,
                Title = training.Title,
                Description = training.Description,
                Date = training.Date
            };
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTraining([FromBody] TrainingDto dto)
        {
            var training = new Training
            {
                Title = dto.Title,
                Description = dto.Description,
                Date = dto.Date
            };
            await _traninRepo.AddAsync(training);
            return CreatedAtAction(nameof(GetTrainingById), new { id = training.Id }, training);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTraining(int id, [FromBody] TrainingDto dto)
        { 
            var training = new Training
            {
                Id = id,
                Title = dto.Title,
                Description = dto.Description,
                Date = dto.Date
            };
            if (id != training.Id)
            {
                return BadRequest();
            }
            await _traninRepo.UpdateAsync(training);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            var existingTraining = await _traninRepo.GetByIdAsync(id);
            if (existingTraining == null)
            {
                return NotFound();
            }
            await _traninRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
