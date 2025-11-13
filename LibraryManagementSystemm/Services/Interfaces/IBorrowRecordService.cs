using LibraryManagementSystemm.Dtos;

namespace LibraryManagementSystemm.Services.Interfaces
{
    public interface IBorrowRecordService
    {
        Task<List<BorrowRecordDto>> GetAllAsync();
        Task<BorrowRecordDto> GetByIdAsync(int id);
        Task AddAsync(BorrowRecordDto dto);
        Task UpdateAsync(int id, BorrowRecordDto dto);
        Task DeleteAsync(int id);
    }
}
