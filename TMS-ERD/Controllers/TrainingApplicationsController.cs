using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Dtos;
using TMS_ERD.Models;
using TMS_ERD.Repository;

namespace TMS_ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingApplicationsController : ControllerBase
    {
        private readonly IGenericRepository<TrainingApplication> _applicationRepository;
        private readonly IGenericRepository<Training> _traingRepository;
        private IGenericRepository<Employee> _employeeRepository;
        private IGenericRepository<Participant> _participantRepository;

        public TrainingApplicationsController(IGenericRepository<TrainingApplication> applicationRepository, IGenericRepository<Training> traingRepository, IGenericRepository<Employee> employeeRepository, IGenericRepository<Participant> participantRepository)
        {
            _applicationRepository = applicationRepository;
            _traingRepository = traingRepository;
            _employeeRepository = employeeRepository;
            _participantRepository = participantRepository;
        }

        // ✅ GET: api/TrainingApplications
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var applications = await _applicationRepository.GetAllAsync();
            var dtos = new List<TrainingApplicationDto>();

            foreach (var application in applications)
            {
                var traing = await _traingRepository.GetByIdAsync(application.TrainingId);
                var employee = await _employeeRepository.GetByIdAsync(application.EmployeeId);

                var appDto = new TrainingApplicationDto
                {
                    Id = application.Id,
                    TrainingId = application.TrainingId,
                    EmployeeId = application.EmployeeId,
                    Status = application.Status,
                    AppliedAt = application.AppliedAt,
                    TrainingTitle = traing.Title,
                    EmployeeName = employee != null ? $"{employee.Name} {employee.Surname}" : null

                };
                dtos.Add(appDto);
            }

            return Ok(dtos);
        }

        // ✅ GET: api/TrainingApplications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null)
                return NotFound(new { message = "Application not found" });

            var dto = new TrainingApplicationDto
            {
                Id = application.Id,
                TrainingId = application.TrainingId,
                EmployeeId = application.EmployeeId,
                Status = application.Status,
                AppliedAt = application.AppliedAt,
                TrainingTitle = application.Training?.Title,
                EmployeeName = application.Employee != null ? $"{application.Employee.Name} {application.Employee.Surname}" : null
            };

            return Ok(dto);
        }

        // ✅ POST: api/TrainingApplications
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrainingApplicationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new TrainingApplication
            {
                TrainingId = dto.TrainingId,
                EmployeeId = dto.EmployeeId,
                Status = string.IsNullOrEmpty(dto.Status) ? "Pending" : dto.Status,
                AppliedAt = dto.AppliedAt == default ? DateTime.UtcNow : dto.AppliedAt
            };

            await _applicationRepository.AddAsync(entity);
            dto.Id = entity.Id;
            dto.AppliedAt = entity.AppliedAt;

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, dto);
        }

        // ✅ PUT: api/TrainingApplications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TrainingApplicationDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch" });

            var existing = await _applicationRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { message = "Application not found" });

            existing.TrainingId = dto.TrainingId;
            existing.EmployeeId = dto.EmployeeId;
            existing.Status = dto.Status;
            existing.AppliedAt = dto.AppliedAt;

            await _applicationRepository.UpdateAsync(existing);
            return NoContent();
        }

        // ✅ DELETE: api/TrainingApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _applicationRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { message = "Application not found" });

            await _applicationRepository.DeleteAsync(id);
            return NoContent();
        }

        // ✅ PUT: api/TrainingApplications/5/status?status=Approved
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
        {
            var validStatuses = new[] { "Pending", "Approved", "Rejected" };
            if (!validStatuses.Contains(status))
                return BadRequest(new { message = "Invalid status value" });

            var application = await _applicationRepository.GetByIdAsync(id);
            if (application == null)
                return NotFound(new { message = "Application not found" });

            application.Status = status;
            await _applicationRepository.UpdateAsync(application);

            if (status == "Approved")
            {

                var partictipant = new Participant()
                {
                    EmployeeId = application.EmployeeId,
                    TrainingId = application.TrainingId,
                    Completed = false,
                    CompletionPercentage=0,
                };
                await _participantRepository.AddAsync(partictipant);
            }

            return Ok(new { message = $"Application status updated to {status}" });
        }
    }
}
