using LibraryManagementSystemm.Dtos;
using LibraryManagementSystemm.Models;
using LibraryManagementSystemm.Repository;
using LibraryManagementSystemm.Services.Interfaces;

namespace LibraryManagementSystemm.Services
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public BookService(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();

            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                TotalCopies = b.TotalCopies,
                AvailableCopies = b.AvailableCopies,
                LibraryId = b.LibraryId
            }).ToList();
        }

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                TotalCopies = book.TotalCopies,
                AvailableCopies = book.AvailableCopies,
                LibraryId = book.LibraryId
            };
        }

        public async Task AddAsync(BookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                TotalCopies = dto.TotalCopies,
                AvailableCopies = dto.AvailableCopies,
                LibraryId = dto.LibraryId
            };

            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateAsync(int id, BookDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return;

            book.Title = dto.Title;
            book.Author = dto.Author;
            book.ISBN = dto.ISBN;
            book.TotalCopies = dto.TotalCopies;
            book.AvailableCopies = dto.AvailableCopies;
            book.LibraryId = dto.LibraryId;

            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                return;

            await _bookRepository.DeleteAsync(id);
        }
    }
}
