using CMSApp.WebAPI.Dtos;

namespace CMSApp.WebAPI.Services.Interfaces
{
    public interface IEnrollmentService
    {
        List<EnrollmentDto> GetAll();
        Task<EnrollmentDto?> GetByIdAsync(int id);
        Task AddAsync(EnrollmentDto dto);
        Task UpdateAsync(EnrollmentDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
