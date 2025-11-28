using Rent_a_Car_Management_System.Dots;

namespace Rent_a_Car_Management_System.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> GetAllAsync();
        Task<PaymentDto> GetByIdAsync(int id);
        Task AddAsync(PaymentDto dto);
        Task UpdateAsync(int id, PaymentDto dto);
        Task DeleteAsync(int id);
    }
}
