using LibraryManagementSystemm.Dtos;

namespace LibraryManagementSystemm.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllAsync();
        Task<BookDto> GetByIdAsync(int id);
        Task AddAsync(BookDto dto);
        Task UpdateAsync(int id, BookDto dto);
        Task DeleteAsync(int id);
    }
}
