
using AİRBNB.BLL.Dtos;

namespace AİRBNB.BLL.Services.Interfaces
{
    public interface IBookingService
    {
        List<BookingDto> GetAll();
        Task<BookingDto?> GetByIdAsync(int id);
        Task AddAsync(BookingDto dto);
        Task UpdateAsync(BookingDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
