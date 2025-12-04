using AutoMapper;
using CMSApp.DAL.Models;
using CMSApp.DAL.Repository;
using CMSApp.WebAPI.Dtos;
using CMSApp.WebAPI.Services.Interfaces;

namespace CMSApp.WebAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(IGenericRepository<Course> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public Task AddAsync(CourseDto dto)
        {
            var entity = _mapper.Map<Course>(dto);
            return _courseRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _courseRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _courseRepository.Exists(id);
        }

        public List<CourseDto> GetAll()
        {
            var entities = _courseRepository.GetAll().ToList();
            return _mapper.Map<List<CourseDto>>(entities);
        }

        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var entity = await _courseRepository.GetByIdAsync(id);
            var dto = _mapper.Map<CourseDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(CourseDto dto)
        {
            // Map DTO to entity
            var entity = _mapper.Map<Course>(dto);
            return _courseRepository.UpdateAsync(entity);
        }
    }
}
