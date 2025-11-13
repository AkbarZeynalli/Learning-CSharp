using LibraryManagementSystemm.Dtos;
using LibraryManagementSystemm.Models;
using LibraryManagementSystemm.Repository;
using LibraryManagementSystemm.Services.Interfaces;

namespace LibraryManagementSystemm.Services
{
    public class BorrowRecordService : IBorrowRecordService
    {
        private readonly IGenericRepository<BorrowRecord> _borrowRepository;

        public BorrowRecordService(IGenericRepository<BorrowRecord> borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }

        public async Task<List<BorrowRecordDto>> GetAllAsync()
        {
            var records = await _borrowRepository.GetAllAsync();

            return records.Select(r => new BorrowRecordDto
            {
                Id = r.Id,
                BookId = r.BookId,
                MemberId = r.MemberId,
                BorrowDate = r.BorrowDate,
                ReturnDate = r.ReturnDate,
                IsReturned = r.IsReturned
            }).ToList();
        }

        public async Task<BorrowRecordDto> GetByIdAsync(int id)
        {
            var record = await _borrowRepository.GetByIdAsync(id);
            if (record == null)
                return null;

            return new BorrowRecordDto
            {
                Id = record.Id,
                BookId = record.BookId,
                MemberId = record.MemberId,
                BorrowDate = record.BorrowDate,
                ReturnDate = record.ReturnDate,
                IsReturned = record.IsReturned
            };
        }

        public async Task AddAsync(BorrowRecordDto dto)
        {
            var record = new BorrowRecord
            {
                BookId = dto.BookId,
                MemberId = dto.MemberId,
                BorrowDate = dto.BorrowDate,
                ReturnDate = dto.ReturnDate,
                IsReturned = dto.IsReturned
            };

            await _borrowRepository.AddAsync(record);
        }

        public async Task UpdateAsync(int id, BorrowRecordDto dto)
        {
            var record = await _borrowRepository.GetByIdAsync(id);
            if (record == null)
                return;

            record.BookId = dto.BookId;
            record.MemberId = dto.MemberId;
            record.BorrowDate = dto.BorrowDate;
            record.ReturnDate = dto.ReturnDate;
            record.IsReturned = dto.IsReturned;

            await _borrowRepository.UpdateAsync(record);
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _borrowRepository.GetByIdAsync(id);
            if (record == null)
                return;

            await _borrowRepository.DeleteAsync(id);
        }
    }
}
