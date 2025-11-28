using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository;
using Hospital_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGenericRepository<Department> _repo;
        private readonly IMapper _mapper;

        public DepartmentService(IGenericRepository<Department> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            var list = await _repo.GetAll().ToListAsync();
            return _mapper.Map<List<DepartmentDto>>(list);
        }

        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            if (data == null) return null;

            return _mapper.Map<DepartmentDto>(data);
        }

        public async Task AddAsync(DepartmentDto dto)
        {
            var entity = _mapper.Map<Department>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, DepartmentDto dto)
        {
            var exist = await _repo.GetByIdAsync(id);
            if (exist == null) return;

            var updated = _mapper.Map<Department>(dto);
            updated.Id = id;

            await _repo.UpdateAsync(updated);
        }

        public async Task DeleteAsync(int id)
        {
            var exist = await _repo.GetByIdAsync(id);
            if (exist == null) return;

            await _repo.DeleteAsync(id);
        }
    }
}
