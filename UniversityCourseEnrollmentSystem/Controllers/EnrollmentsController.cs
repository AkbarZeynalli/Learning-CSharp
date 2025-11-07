using Microsoft.AspNetCore.Mvc;
using UniversityCourseEnrollmentSystem.Models;
using UniversityCourseEnrollmentSystem.Repository;
using UniversityCourseEnrollmentSystem.Dtos;

namespace UniversityCourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IGenericRepository<Enrollment> _enrollmentRepository;

        public EnrollmentsController(IGenericRepository<Enrollment> enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        // 🔹 GET: api/Enrollments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _enrollmentRepository.GetAllAsync();

            var enrollmentDtos = enrollments.Select(e => new EnrollmentDto
            {
                Id = e.Id,
                StudentId = e.StudentId,
                CourseId = e.CourseId,
                EnrolledAt = e.EnrolledAt,
                Status = e.Status.ToString(),
                Grade = e.Grade
            }).ToList();

            return Ok(enrollmentDtos);
        }

        // 🔹 GET: api/Enrollments/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(id);
            if (enrollment == null)
                return NotFound();

            var dto = new EnrollmentDto
            {
                Id = enrollment.Id,
                StudentId = enrollment.StudentId,
                CourseId = enrollment.CourseId,
                EnrolledAt = enrollment.EnrolledAt,
                Status = enrollment.Status.ToString(),
                Grade = enrollment.Grade
            };

            return Ok(dto);
        }

        // 🔹 POST: api/Enrollments
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnrollmentDto dto)
        {
            var enrollment = new Enrollment
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                EnrolledAt = dto.EnrolledAt == default ? DateTime.UtcNow : dto.EnrolledAt,
                Status = Enum.TryParse(dto.Status, out EnrollmentStatus status) ? status : EnrollmentStatus.Pending,
                Grade = dto.Grade
            };

            await _enrollmentRepository.AddAsync(enrollment);
            return CreatedAtAction(nameof(GetById), new { id = enrollment.Id }, enrollment);
        }

        // 🔹 PUT: api/Enrollments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EnrollmentDto dto)
        {
            var existing = await _enrollmentRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.StudentId = dto.StudentId;
            existing.CourseId = dto.CourseId;
            existing.EnrolledAt = dto.EnrolledAt;
            existing.Status = Enum.TryParse(dto.Status, out EnrollmentStatus status) ? status : existing.Status;
            existing.Grade = dto.Grade;

            await _enrollmentRepository.UpdateAsync(existing);
            return NoContent();
        }

        // 🔹 DELETE: api/Enrollments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _enrollmentRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _enrollmentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
