using AutoMapper;
using CMSApp.DAL.Models;
using CMSApp.DAL.Repository;
using CMSApp.WebAPI.Dtos;
using CMSApp.WebAPI.Services.Interfaces;

namespace CMSApp.WebAPI.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IGenericRepository<Enrollment> _entrollmentRepository;
        private readonly IMapper _mapper;

        public EnrollmentService(IGenericRepository<Enrollment> entrollmentRepository, IMapper mapper)
        {
            _entrollmentRepository = entrollmentRepository;
            _mapper = mapper;
        }

        public Task AddAsync(EnrollmentDto dto)
        {
            var entity = _mapper.Map<Enrollment>(dto);
            return _entrollmentRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _entrollmentRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _entrollmentRepository.Exists(id);
        }

        public List<EnrollmentDto> GetAll()
        {
            var entities = _entrollmentRepository.GetAll().ToList();
            return _mapper.Map<List<EnrollmentDto>>(entities);
        }

        public async Task<EnrollmentDto?> GetByIdAsync(int id)
        {
            var entity = await _entrollmentRepository.GetByIdAsync(id);
            var dto = _mapper.Map<EnrollmentDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(EnrollmentDto dto)
        {
            // Map DTO to entity
            var entity = _mapper.Map<Enrollment>(dto);
            return _entrollmentRepository.UpdateAsync(entity);
        }
    }
}
