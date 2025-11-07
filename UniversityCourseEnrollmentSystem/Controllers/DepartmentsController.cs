using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityCourseEnrollmentSystem.Data;
using UniversityCourseEnrollmentSystem.Models;
using UniversityCourseEnrollmentSystem.Dtos;

namespace UniversityCourseEnrollmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentsController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET /api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        // 🔹 GET /api/Departments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            return department;
        }

        // 🔹 POST /api/Departments
        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment([FromBody] DepartmentDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                Office = dto.Office,
                Phone = dto.Phone
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
        }

        // 🔹 PUT /api/Departments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentDto dto)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();

            department.Name = dto.Name;
            department.Office = dto.Office;
            department.Phone = dto.Phone;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 🔹 DELETE /api/Departments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
