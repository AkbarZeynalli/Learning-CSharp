using Rent_a_Car_Management_System.Dots;

namespace Rent_a_Car_Management_System.Services.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandDto>> GetAllAsync();
        Task<BrandDto> GetByIdAsync(int id);
        Task AddAsync(BrandDto dto);
        Task UpdateAsync(int id, BrandDto dto);
        Task DeleteAsync(int id);
    }
}
