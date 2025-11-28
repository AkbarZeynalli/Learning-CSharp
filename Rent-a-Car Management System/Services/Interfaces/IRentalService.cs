using Rent_a_Car_Management_System.Dots;

namespace Rent_a_Car_Management_System.Services.Interfaces
{
    public interface IRentalService
    {
        Task<List<RentalDto>> GetAllAsync();
        Task<RentalDto> GetByIdAsync(int id);
        Task AddAsync(RentalDto dto);
        Task UpdateAsync(int id, RentalDto dto);
        Task DeleteAsync(int id);
    }
}
