using FMS.WebAPI.Dtos;

namespace FMS.WebAPI.Services.Interfaces
{
    public interface IPositionServices
    {
        List<PositionDto> GetAll();
        Task<PositionDto?> GetByIdAsync(int id);
        Task AddAsync(PositionDto dto);
        Task UpdateAsync(PositionDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
