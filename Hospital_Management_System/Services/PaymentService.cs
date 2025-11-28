using AutoMapper;
using Hospital_Management_System.Dtos;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repository;
using Hospital_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Payment> _repo;
        private readonly IMapper _mapper;

        public PaymentService(IGenericRepository<Payment> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<PaymentDto>> GetAllAsync()
        {
            var list = await _repo.GetAll().ToListAsync();
            return _mapper.Map<List<PaymentDto>>(list);
        }

        public async Task<PaymentDto?> GetByIdAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null) return null;

            return _mapper.Map<PaymentDto>(item);
        }

        public async Task AddAsync(PaymentDto dto)
        {
            var entity = _mapper.Map<Payment>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, PaymentDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return;

            var entity = _mapper.Map<Payment>(dto);
            entity.Id = id;

            await _repo.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
