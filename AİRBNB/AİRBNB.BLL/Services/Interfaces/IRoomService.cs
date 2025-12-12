using AİRBNB.BLL.Dtos;

namespace AİRBNB.BLL.Services.Interfaces
{
    public interface IRoomService
    {
        List<RoomDto> GetAll();
        Task<RoomDto?> GetByIdAsync(int id);
        Task AddAsync(RoomDto dto);
        Task UpdateAsync(RoomDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
