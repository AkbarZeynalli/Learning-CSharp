using FMS.WebAPI.Dtos;

namespace FMS.WebAPI.Services.Interfaces
{
    public interface IClubServices
    {
        List<ClubDto> GetAll();
        Task<ClubDto?> GetByIdAsync(int id);
        Task AddAsync(ClubDto dto);
        Task UpdateAsync(ClubDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
