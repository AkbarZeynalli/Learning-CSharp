using RestaurantManagementSystem.Dtos;

namespace RestaurantManagementSystem.Services.Interfaces
{
    public interface ITableService
    {
        Task<List<TableDto>> GetAllAsync();
        Task<TableDto> GetByIdAsync(int id);
        Task AddAsync(TableDto dto);
        Task UpdateAsync(int id, TableDto dto);
        Task DeleteAsync(int id);
    }
}
