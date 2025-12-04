using AutoMapper;
using UMSApp.DAL.Models;
using UMSApp.DAL.Repository;
using UMSApp.WebAPI.Dtos;
using UMSApp.WebAPI.Services.Interfaces;

namespace UMSApp.WebAPI.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IGenericRepository<University> _universityRepository;
        private readonly IMapper _mapper;

        public UniversityService(IGenericRepository<University> universityRepository, IMapper mapper)
        {
            _universityRepository = universityRepository;
            _mapper = mapper;
        }

        public Task AddAsync(UniversityDto dto)
        {
            var entity = _mapper.Map<University>(dto);
            return _universityRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _universityRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _universityRepository.Exists(id);
        }

        public List<UniversityDto> GetAll()
        {
            var entities = _universityRepository.GetAll().ToList();
            return _mapper.Map<List<UniversityDto>>(entities);
        }

        public async Task<UniversityDto?> GetByIdAsync(int id)
        {
            var entity = await _universityRepository.GetByIdAsync(id);
            var dto = _mapper.Map<UniversityDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(UniversityDto dto)
        {
            // Map DTO to entity
            var entity = _mapper.Map<University>(dto);
            return _universityRepository.UpdateAsync(entity);
        }

    }
}
