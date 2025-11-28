using Hospital_Management_System.Dtos;

namespace Hospital_Management_System.Services.Interfaces
{
    public interface ISpecializationService
    {
        Task<List<SpecializationDto>> GetAllAsync();
        Task<SpecializationDto> GetByIdAsync(int id);
        Task AddAsync(SpecializationDto dto);
        Task UpdateAsync(int id, SpecializationDto dto);
        Task DeleteAsync(int id);
    }
}
