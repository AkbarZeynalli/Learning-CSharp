using LibraryManagementSystemm.Dtos;
using LibraryManagementSystemm.Models;
using LibraryManagementSystemm.Repository;
using LibraryManagementSystemm.Services.Interfaces;

namespace LibraryManagementSystemm.Services
{
    public class LibraryService : ILibraryService
    {

        private IGenericRepository<Library> _libraryRepository;

        public LibraryService(IGenericRepository<Library> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task AddAsync(LibraryDto dto)
        {
            var library = new Library
            {
                Name = dto.Name,
                Location = dto.Location,
                Phone = dto.Phone
            };

            await _libraryRepository.AddAsync(library);
        }

        public async Task DeleteAsync(int id)
        {
            var library = await _libraryRepository.GetByIdAsync(id);
            if (library == null)
                return ;

            await _libraryRepository.DeleteAsync(id);
        }

        public async Task<List<LibraryDto>> GetAllAsync()
        {
            var libraries = await _libraryRepository.GetAllAsync();

            var dtoList = libraries.Select(x => new LibraryDto
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
                Phone = x.Phone
            });
            return dtoList.ToList();
        }

        public async Task<LibraryDto> GetByIdAsync(int id)
        {
            var library = await _libraryRepository.GetByIdAsync(id);
            if (library == null)
                return null;

            var dto = new LibraryDto
            {
                Id = library.Id,
                Name = library.Name,
                Location = library.Location,
                Phone = library.Phone
            };
            return dto;

        }

        public async Task UpdateAsync(int id, LibraryDto dto)
        {
            var library = await _libraryRepository.GetByIdAsync(id);
            if (library == null)
                return;

            library.Name = dto.Name;
            library.Location = dto.Location;
            library.Phone = dto.Phone;

            await _libraryRepository.UpdateAsync(library);
        }
    }
}
