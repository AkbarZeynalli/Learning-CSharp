using AutoMapper;
using UMSApp.DAL.Models;
using UMSApp.DAL.Repository;
using UMSApp.WebAPI.Dtos;
using UMSApp.WebAPI.Services.Interfaces;

namespace UMSApp.WebAPI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IGenericRepository<Teacher> _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherService(IGenericRepository<Teacher> teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public Task AddAsync(TeacherDto dto)
        {
            var entity = _mapper.Map<Teacher>(dto);
            return _teacherRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _teacherRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _teacherRepository.Exists(id);
        }

        public List<TeacherDto> GetAll()
        {
            var entities = _teacherRepository.GetAll().ToList();
            return _mapper.Map<List<TeacherDto>>(entities);
        }

        public async Task<TeacherDto?> GetByIdAsync(int id)
        {
            var entity = await _teacherRepository.GetByIdAsync(id);
            var dto = _mapper.Map<TeacherDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(TeacherDto dto)
        {
            // Map DTO to entity
            var entity = _mapper.Map<Teacher>(dto);
            return _teacherRepository.UpdateAsync(entity);
        }
    }
}
