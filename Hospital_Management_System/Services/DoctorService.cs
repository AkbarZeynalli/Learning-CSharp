using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository;
using Hospital_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IGenericRepository<Doctor> _repo;
        private readonly IMapper _mapper;

        public DoctorService(IGenericRepository<Doctor> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<DoctorDto>> GetAllAsync()
        {
            var docs = await _repo.GetAll().ToListAsync();
            return _mapper.Map<List<DoctorDto>>(docs);
        }

        public async Task<DoctorDto?> GetByIdAsync(int id)
        {
            var doc = await _repo.GetByIdAsync(id);
            return _mapper.Map<DoctorDto>(doc);
        }

        public async Task AddAsync(DoctorDto dto)
        {
            var entity = _mapper.Map<Doctor>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, DoctorDto dto)
        {
            var entity = _mapper.Map<Doctor>(dto);
            entity.Id = id;
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
