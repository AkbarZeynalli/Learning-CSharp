using FMS.WebAPI.Dtos;

namespace FMS.WebAPI.Services.Interfaces
{
    public interface IGoalServices
    {
        List<GoalDto> GetAll();
        Task<GoalDto?> GetByIdAsync(int id);
        Task AddAsync(GoalDto dto);
        Task UpdateAsync(GoalDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
