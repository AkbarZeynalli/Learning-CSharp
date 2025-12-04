using UMSApp.WebAPI.Dtos;

namespace UMSApp.WebAPI.Services.Interfaces
{
    public interface IUniversityService
    {
        List<UniversityDto> GetAll();
        Task<UniversityDto?> GetByIdAsync(int id);
        Task AddAsync(UniversityDto dto);
        Task UpdateAsync(UniversityDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
