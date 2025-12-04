using UMSApp.WebAPI.Dtos;

namespace UMSApp.WebAPI.Services.Interfaces
{
    public interface IStudentService
    {
        List<StudentDto> GetAll();
        Task<StudentDto?> GetByIdAsync(int id);
        Task AddAsync(StudentDto dto);
        Task UpdateAsync(StudentDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
