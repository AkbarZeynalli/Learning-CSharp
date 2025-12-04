using AutoMapper;
using CMSApp.DAL.Models;
using CMSApp.DAL.Repository;
using CMSApp.WebAPI.Dtos;
using CMSApp.WebAPI.Services.Interfaces;

namespace CMSApp.WebAPI.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IGenericRepository<Instructor> _instructorRepository;
        private readonly IMapper _mapper;

        public InstructorService(IGenericRepository<Instructor> instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public Task AddAsync(InstructorDto dto)
        {
            var entity = _mapper.Map<Instructor>(dto);
            return _instructorRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _instructorRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _instructorRepository.Exists(id);
        }

        public List<InstructorDto> GetAll()
        {
            var entities = _instructorRepository.GetAll().ToList();
            return _mapper.Map<List<InstructorDto>>(entities);
        }

        public async Task<InstructorDto?> GetByIdAsync(int id)
        {
            var entity = await _instructorRepository.GetByIdAsync(id);
            var dto = _mapper.Map<InstructorDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(InstructorDto dto)
        {
            // Map DTO to entity
            var entity = _mapper.Map<Instructor>(dto);
            return _instructorRepository.UpdateAsync(entity);
        }
    }
}
