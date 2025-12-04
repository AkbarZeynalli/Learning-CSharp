using AutoMapper;
using CMSApp.DAL.Models;
using CMSApp.DAL.Repository;
using CMSApp.WebAPI.Dtos;
using CMSApp.WebAPI.Services.Interfaces;

namespace CMSApp.WebAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IGenericRepository<Student> studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public Task AddAsync(StudentDto dto)
        {
            var entity = _mapper.Map<Student>(dto);
            return _studentRepository.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {

            return _studentRepository.DeleteAsync(id);
        }

        public Task<bool> Exists(int id)
        {
            return _studentRepository.Exists(id);
        }

        public List<StudentDto> GetAll()
        {
            var entities = _studentRepository.GetAll().ToList();
            return _mapper.Map<List<StudentDto>>(entities);
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var entity = await _studentRepository.GetByIdAsync(id);
            var dto = _mapper.Map<StudentDto?>(entity);
            return dto;
        }

        public Task UpdateAsync(StudentDto dto)
        {
            // Map DTO to entity
            var entity = _mapper.Map<Student>(dto);
            return _studentRepository.UpdateAsync(entity);
        }
    }
}
