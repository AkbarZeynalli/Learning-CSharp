using UMSApp.WebAPI.Dtos;

namespace UMSApp.WebAPI.Services.Interfaces
{
    public interface ITeacherService
    {
        List<TeacherDto> GetAll();
        Task<TeacherDto?> GetByIdAsync(int id);
        Task AddAsync(TeacherDto dto);
        Task UpdateAsync(TeacherDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
