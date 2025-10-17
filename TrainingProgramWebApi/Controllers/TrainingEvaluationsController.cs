using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingProgramWebApi.Dtos;
using TrainingProgramWebApi.Models;
using TrainingProgramWebApi.Repository;

namespace TrainingProgramWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingEvaluationsController : ControllerBase
    {
        private readonly IGenericRepository<TrainingEvaluation> _trainingEvaluationRepository;
        public TrainingEvaluationsController(IGenericRepository<TrainingEvaluation> trainingEvaluationRepository)
        {
            _trainingEvaluationRepository = trainingEvaluationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainingEvaluations()
        {
            var evaluations = await _trainingEvaluationRepository.GetAllAsync();
            var evaluationDtos = evaluations.Select(e => new TrainingEvaluationDto
            {
                Id = e.Id,
                TrainingId = e.TrainingId,
                Score = e.Score,
                Comment = e.Comment,
                JudgeId = e.JudgeId,
                TeacherId = e.TeacherId
            }).ToList();

            return Ok(evaluationDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingEvaluationById(int id)
        {
            var evaluation = await _trainingEvaluationRepository.GetByIdAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }

            var dto = new TrainingEvaluationDto
            {
                Id = evaluation.Id,
                TrainingId = evaluation.TrainingId,
                Score = evaluation.Score,
                Comment = evaluation.Comment,
                JudgeId = evaluation.JudgeId,
                TeacherId = evaluation.TeacherId
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainingEvaluation([FromBody] TrainingEvaluationDto dto)
        {
            if (dto == null) return BadRequest();

            var evaluation = new TrainingEvaluation
            {
                TrainingId = dto.TrainingId,
                Score = dto.Score,
                Comment = dto.Comment,
                JudgeId = dto.JudgeId,
                TeacherId = dto.TeacherId
            };

            await _trainingEvaluationRepository.AddAsync(evaluation);

            var createdDto = new TrainingEvaluationDto
            {
                Id = evaluation.Id,
                TrainingId = evaluation.TrainingId,
                Score = evaluation.Score,
                Comment = evaluation.Comment,
                JudgeId = evaluation.JudgeId,
                TeacherId = evaluation.TeacherId
            };

            return CreatedAtAction(nameof(GetTrainingEvaluationById), new { id = evaluation.Id }, createdDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingEvaluation(int id, [FromBody] TrainingEvaluationDto dto)
        {
            if (dto == null) return BadRequest();
            if (id != dto.Id && dto.Id != 0) return BadRequest();

            var existing = await _trainingEvaluationRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.TrainingId = dto.TrainingId;
            existing.Score = dto.Score;
            existing.Comment = dto.Comment;
            existing.JudgeId = dto.JudgeId;
            existing.TeacherId = dto.TeacherId;

            await _trainingEvaluationRepository.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingEvaluation(int id)
        {
            var existingEvaluation = await _trainingEvaluationRepository.GetByIdAsync(id);
            if (existingEvaluation == null)
            {
                return NotFound();
            }
            await _trainingEvaluationRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
