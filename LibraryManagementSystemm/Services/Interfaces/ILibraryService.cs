using LibraryManagementSystemm.Dtos;

namespace LibraryManagementSystemm.Services.Interfaces
{
    public interface ILibraryService
    {
        Task<List<LibraryDto>> GetAllAsync();
        Task<LibraryDto> GetByIdAsync(int id);
        Task AddAsync(LibraryDto dto);
        Task UpdateAsync(int id, LibraryDto dto);
        Task DeleteAsync(int id);
    }
}
