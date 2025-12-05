using FMS.WebAPI.Dtos;

namespace FMS.WebAPI.Services.Interfaces
{
    public interface ILeaugeServies
    {
        List<LeaugeDto> GetAll();
        Task<LeaugeDto?> GetByIdAsync(int id);
        Task AddAsync(LeaugeDto dto);
        Task UpdateAsync(LeaugeDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
