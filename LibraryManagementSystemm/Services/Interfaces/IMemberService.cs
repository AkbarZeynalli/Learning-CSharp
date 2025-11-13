using LibraryManagementSystemm.Dtos;

namespace LibraryManagementSystemm.Services.Interfaces
{
    public interface IMemberService
    {
        Task<List<MemberDto>> GetAllAsync();
        Task<MemberDto> GetByIdAsync(int id);
        Task AddAsync(MemberDto dto);
        Task UpdateAsync(int id, MemberDto dto);
        Task DeleteAsync(int id);
    }
}
