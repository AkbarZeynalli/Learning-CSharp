using Rent_a_Car_Management_System.Dots;

namespace Rent_a_Car_Management_System.Services.Interfaces
{
    public interface ICarModelService
    {
        Task<List<CarModelDto>> GetAllAsync();
        Task<List<CarModelDto>> GetByBrandId(int brandId);  
        Task<CarModelDto> GetByIdAsync(int id);
        Task AddAsync(CarModelDto dto);
        Task UpdateAsync(int id, CarModelDto dto);
        Task DeleteAsync(int id);
    }
}
