using CMSApp.WebAPI.Dtos;

namespace CMSApp.WebAPI.Services.Interfaces
{
    public interface IInstructorService
    {
        List<InstructorDto> GetAll();
        Task<InstructorDto?> GetByIdAsync(int id);
        Task AddAsync(InstructorDto dto);
        Task UpdateAsync(InstructorDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
