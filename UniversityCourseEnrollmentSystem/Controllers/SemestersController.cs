using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityCourseEnrollmentSystem.Data;
using UniversityCourseEnrollmentSystem.Dtos;
using UniversityCourseEnrollmentSystem.Models;

namespace UniversityCourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SemestersController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET: api/Semesters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SemesterDto>>> GetAllSemesters()
        {
            var semesters = await _context.Semesters.ToListAsync();

            var semesterDtos = semesters.Select(s => new SemesterDto
            {
                Id = s.Id,
                Name = s.Name,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            }).ToList();

            return Ok(semesterDtos);
        }

        // 🔹 GET: api/Semesters/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterDto>> GetSemesterById(int id)
        {
            var semester = await _context.Semesters.FindAsync(id);
            if (semester == null)
                return NotFound();

            var dto = new SemesterDto
            {
                Id = semester.Id,
                Name = semester.Name,
                StartDate = semester.StartDate,
                EndDate = semester.EndDate
            };

            return Ok(dto);
        }

        // 🔹 POST: api/Semesters
        [HttpPost]
        public async Task<ActionResult<Semester>> CreateSemester([FromBody] SemesterDto dto)
        {
            var semester = new Semester
            {
                Name = dto.Name,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };

            _context.Semesters.Add(semester);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSemesterById), new { id = semester.Id }, semester);
        }

        // 🔹 PUT: api/Semesters/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSemester(int id, [FromBody] SemesterDto dto)
        {
            var existing = await _context.Semesters.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = dto.Name;
            existing.StartDate = dto.StartDate;
            existing.EndDate = dto.EndDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 🔹 DELETE: api/Semesters/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(int id)
        {
            var semester = await _context.Semesters.FindAsync(id);
            if (semester == null)
                return NotFound();

            _context.Semesters.Remove(semester);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
