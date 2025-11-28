using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository;
using Hospital_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class SpecializationService : ISpecializationService
    {
        private readonly IGenericRepository<Specialization> _repo;
        private readonly IMapper _mapper;

        public SpecializationService(IGenericRepository<Specialization> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<SpecializationDto>> GetAllAsync()
        {
            var entities = await _repo.GetAll().ToListAsync();
            return _mapper.Map<List<SpecializationDto>>(entities);
        }

        public async Task<SpecializationDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<SpecializationDto>(entity);
        }

        public async Task AddAsync(SpecializationDto dto)
        {
            var entity = _mapper.Map<Specialization>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, SpecializationDto dto)
        {
            var entity = _mapper.Map<Specialization>(dto);
            entity.Id = id;
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
