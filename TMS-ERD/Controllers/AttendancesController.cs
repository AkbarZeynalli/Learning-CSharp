using Microsoft.AspNetCore.Mvc;
using TMS_ERD.Models;
using TMS_ERD.Repository;
using TrainingProgramWebApi.Dtos;

namespace TrainingProgramWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IGenericRepository<Attendance> _attendanceRepository;

        public AttendancesController(IGenericRepository<Attendance> attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        // 🔹 GET: api/Attendances
        [HttpGet]
        public async Task<IActionResult> GetAllAttendances()
        {
            var attendances = await _attendanceRepository.GetAllAsync();

            var attendanceDtos = attendances.Select(a => new AttendanceDto
            {
                Id = a.Id,
                TrainingSessionId = a.TrainingSessionId,
                ParticipantId = a.ParticipantId,
                CheckInAt = a.CheckInAt,
                CheckOutAt = a.CheckOutAt,
                IsPresent = a.IsPresent
            }).ToList();

            return Ok(attendanceDtos);
        }

        // 🔹 GET: api/Attendances/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceById(int id)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(id);
            if (attendance == null)
                return NotFound();

            var dto = new AttendanceDto
            {
                Id = attendance.Id,
                TrainingSessionId = attendance.TrainingSessionId,
                ParticipantId = attendance.ParticipantId,
                CheckInAt = attendance.CheckInAt,
                CheckOutAt = attendance.CheckOutAt,
                IsPresent = attendance.IsPresent
            };

            return Ok(dto);
        }

        // 🔹 POST: api/Attendances
        [HttpPost]
        public async Task<IActionResult> CreateAttendance([FromBody] AttendanceDto dto)
        {
            var attendance = new Attendance
            {
                TrainingSessionId = dto.TrainingSessionId,
                ParticipantId = dto.ParticipantId,
                CheckInAt = dto.CheckInAt,
                CheckOutAt = dto.CheckOutAt,
                IsPresent = dto.IsPresent
            };

            await _attendanceRepository.AddAsync(attendance);
            return CreatedAtAction(nameof(GetAttendanceById), new { id = attendance.Id }, attendance);
        }

        // 🔹 PUT: api/Attendances/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, [FromBody] AttendanceDto dto)
        {
            var existing = await _attendanceRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.TrainingSessionId = dto.TrainingSessionId;
            existing.ParticipantId = dto.ParticipantId;
            existing.CheckInAt = dto.CheckInAt;
            existing.CheckOutAt = dto.CheckOutAt;
            existing.IsPresent = dto.IsPresent;

            await _attendanceRepository.UpdateAsync(existing);
            return NoContent();
        }

        // 🔹 DELETE: api/Attendances/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var existing = await _attendanceRepository.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _attendanceRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
