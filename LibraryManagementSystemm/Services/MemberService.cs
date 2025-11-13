using LibraryManagementSystemm.Dtos;
using LibraryManagementSystemm.Models;
using LibraryManagementSystemm.Repository;
using LibraryManagementSystemm.Services.Interfaces;

namespace LibraryManagementSystemm.Services
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepository<Member> _memberRepository;

        public MemberService(IGenericRepository<Member> memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<List<MemberDto>> GetAllAsync()
        {
            var members = await _memberRepository.GetAllAsync();

            return members.Select(m => new MemberDto
            {
                Id = m.Id,
                FullName = m.FullName,
                Email = m.Email,
                Phone = m.Phone
            }).ToList();
        }

        public async Task<MemberDto> GetByIdAsync(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
                return null;

            return new MemberDto
            {
                Id = member.Id,
                FullName = member.FullName,
                Email = member.Email,
                Phone = member.Phone
            };
        }

        public async Task AddAsync(MemberDto dto)
        {
            var member = new Member
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone
            };

            await _memberRepository.AddAsync(member);
        }

        public async Task UpdateAsync(int id, MemberDto dto)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
                return;

            member.FullName = dto.FullName;
            member.Email = dto.Email;
            member.Phone = dto.Phone;

            await _memberRepository.UpdateAsync(member);
        }

        public async Task DeleteAsync(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
                return;

            await _memberRepository.DeleteAsync(id);
        }
    }
}
