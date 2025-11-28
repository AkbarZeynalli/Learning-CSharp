using Rent_a_Car_Management_System.Dots;

namespace Rent_a_Car_Management_System.Services.Interfaces
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
