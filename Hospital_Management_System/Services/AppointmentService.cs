using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository;
using Hospital_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IGenericRepository<Appointment> _repo;
        private readonly IMapper _mapper;

        public AppointmentService(IGenericRepository<Appointment> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<AppointmentDto>> GetAllAsync()
        {
            var list = await _repo.GetAll().ToListAsync();
            return _mapper.Map<List<AppointmentDto>>(list);
        }

        public async Task<AppointmentDto?> GetByIdAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            return _mapper.Map<AppointmentDto>(item);
        }

        public async Task AddAsync(AppointmentDto dto)
        {
            var entity = _mapper.Map<Appointment>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, AppointmentDto dto)
        {
            var entity = _mapper.Map<Appointment>(dto);
            entity.Id = id;
            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
