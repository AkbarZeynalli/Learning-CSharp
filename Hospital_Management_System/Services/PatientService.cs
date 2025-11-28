using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository;
using Hospital_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class PatientService : IPatientService
    {
        private readonly IGenericRepository<Patient> _repo;
        private readonly IMapper _mapper;

        public PatientService(IGenericRepository<Patient> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> GetAllAsync()
        {
            var items = await _repo.GetAll().ToListAsync();
            return _mapper.Map<List<PatientDto>>(items);
        }

        public async Task<PatientDto?> GetByIdAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            return _mapper.Map<PatientDto>(item);
        }

        public async Task AddAsync(PatientDto dto)
        {
            var entity = _mapper.Map<Patient>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, PatientDto dto)
        {
            var entity = _mapper.Map<Patient>(dto);
            entity.Id = id;
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
