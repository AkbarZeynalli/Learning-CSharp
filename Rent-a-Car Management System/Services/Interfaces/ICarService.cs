using Rent_a_Car_Management_System.Dots;

namespace Rent_a_Car_Management_System.Services.Interfaces
{
    public interface ICarService
    {
        Task<List<CarDto>> GetAllAsync();
        Task<CarDto> GetByIdAsync(int id);
        Task AddAsync(CarDto dto);
        Task UpdateAsync(int id, CarDto dto);
        Task DeleteAsync(int id);
        Task<List<CarDto>>GetByModelId(int modelId);
        Task<List<CarDto>> GetByBrandId(int brandId);
    }
}
