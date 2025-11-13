using RestaurantManagementSystem.Dtos;

namespace RestaurantManagementSystem.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<List<InventoryDto>> GetAllAsync();
        Task<InventoryDto> GetByIdAsync(int id);
        Task AddAsync(InventoryDto dto);
        Task UpdateAsync(int id, InventoryDto dto);
        Task DeleteAsync(int id);
    }
}
