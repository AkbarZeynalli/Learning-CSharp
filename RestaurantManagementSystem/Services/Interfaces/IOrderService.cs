using RestaurantManagementSystem.Dtos;

namespace RestaurantManagementSystem.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int id);
        Task AddAsync(OrderDto dto);
        Task UpdateAsync(int id, OrderDto dto);
        Task DeleteAsync(int id);
    }
}
