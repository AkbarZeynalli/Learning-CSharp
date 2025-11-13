using RestaurantManagementSystem.Dtos;

namespace RestaurantManagementSystem.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuItemDto>> GetAllAsync();
        Task<MenuItemDto> GetByIdAsync(int id);
        Task AddAsync(MenuItemDto dto);
        Task UpdateAsync(int id, MenuItemDto dto);
        Task DeleteAsync(int id);
    }
}
