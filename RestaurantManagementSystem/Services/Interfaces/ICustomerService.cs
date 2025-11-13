using RestaurantManagementSystem.Dtos;

namespace RestaurantManagementSystem.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByIdAsync(int id);
        Task AddAsync(CustomerDto dto);
        Task UpdateAsync(int id, CustomerDto dto);
        Task DeleteAsync(int id);
    }
}
