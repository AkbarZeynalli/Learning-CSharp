using FMS.WebAPI.Dtos;

namespace FMS.WebAPI.Services.Interfaces
{
    public interface IMatchServices
    {
        List<MatchDto> GetAll();
        Task<MatchDto?> GetByIdAsync(int id);
        Task AddAsync(MatchDto dto);
        Task UpdateAsync(MatchDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
