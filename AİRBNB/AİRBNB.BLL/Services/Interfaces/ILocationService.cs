using AİRBNB.BLL.Dtos;

namespace AİRBNB.BLL.Services.Interfaces
{
    public interface ILocationService
    {
        List<LocationDto> GetAll();
        Task<LocationDto?> GetByIdAsync(int id);
        Task AddAsync(LocationDto dto);
        Task UpdateAsync(LocationDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
