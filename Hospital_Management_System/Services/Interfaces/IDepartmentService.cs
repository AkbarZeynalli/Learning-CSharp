using Hospital_Management_System.Dtos;

namespace Hospital_Management_System.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto?> GetByIdAsync(int id);
        Task AddAsync(DepartmentDto dto);
        Task UpdateAsync(int id, DepartmentDto dto);
        Task DeleteAsync(int id);
    }
}
