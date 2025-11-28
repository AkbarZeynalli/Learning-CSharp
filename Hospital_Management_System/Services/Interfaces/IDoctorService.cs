using Hospital_Management_System.Dtos;

namespace Hospital_Management_System.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllAsync();
        Task<DoctorDto> GetByIdAsync(int id);
        Task AddAsync(DoctorDto dto);
        Task UpdateAsync(int id, DoctorDto dto);
        Task DeleteAsync(int id);
    }
}
