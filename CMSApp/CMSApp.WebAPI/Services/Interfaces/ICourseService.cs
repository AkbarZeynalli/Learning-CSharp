using CMSApp.WebAPI.Dtos;

namespace CMSApp.WebAPI.Services.Interfaces
{
    public interface ICourseService
    {
        List<CourseDto> GetAll();
        Task<CourseDto?> GetByIdAsync(int id);
        Task AddAsync(CourseDto dto);
        Task UpdateAsync(CourseDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
