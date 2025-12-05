using FMS.WebAPI.Dtos;

namespace FMS.WebAPI.Services.Interfaces
{
    public interface IPlayerServices
    {
        List<PlayerDto> GetAll();
        Task<PlayerDto?> GetByIdAsync(int id);
        Task AddAsync(PlayerDto dto);
        Task UpdateAsync(PlayerDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
