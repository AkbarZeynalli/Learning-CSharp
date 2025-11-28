using Hospital_Management_System.Dtos;

namespace Hospital_Management_System.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto> GetByIdAsync(int id);
        Task AddAsync(AppointmentDto dto);
        Task UpdateAsync(int id, AppointmentDto dto);
        Task DeleteAsync(int id);
    }
}
