using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Models;
using TMS_ERD.Repository;
using TMS_ERD.Dtos;

namespace TMS_ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeesController(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // 🔹 GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeeDtos = employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Email = e.Email
            }).ToList();

            return Ok(employeeDtos);
        }

        // 🔹 GET: api/Employees/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            var dto = new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Email = employee.Email
            };

            return Ok(dto);
        }

        // 🔹 POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = new Employee
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email
            };

            await _employeeRepository.AddAsync(employee);

            dto.Id = employee.Id; // cavabda göstərmək üçün

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, dto);
        }

        // 🔹 PUT: api/Employees/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDto dto)
        {
            var existing = await _employeeRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = dto.Name;
            existing.Surname = dto.Surname;
            existing.Email = dto.Email;

            await _employeeRepository.UpdateAsync(existing);
            return NoContent();
        }

        // 🔹 DELETE: api/Employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var existing = await _employeeRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _employeeRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
