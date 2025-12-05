using FMS.WebAPI.Dtos;

namespace FMS.WebAPI.Services.Interfaces
{
    public interface ICountryServices
    {
        List<CountryDto> GetAll();
        Task<CountryDto?> GetByIdAsync(int id);
        Task AddAsync(CountryDto dto);
        Task UpdateAsync(CountryDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
