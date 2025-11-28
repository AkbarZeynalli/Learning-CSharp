using Hospital_Management_System.Dtos;

public interface IPaymentService
{
    Task<List<PaymentDto>> GetAllAsync();
    Task<PaymentDto?> GetByIdAsync(int id);
    Task AddAsync(PaymentDto dto);
    Task UpdateAsync(int id, PaymentDto dto);
    Task DeleteAsync(int id);
}
