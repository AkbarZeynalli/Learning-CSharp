using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Models;
using Rent_a_Car_Management_System.Repository;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Payment> _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IGenericRepository<Payment> paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentDto>> GetAllAsync()
        {
            var payments = await _paymentRepository.GetAll().ToListAsync();

            var dtos = _mapper.Map<List<PaymentDto>>(payments);
            return dtos;
        }

        public async Task<PaymentDto> GetByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null) return null;

            var dto = _mapper.Map<PaymentDto>(payment);
            return dto;
        }

        public async Task AddAsync(PaymentDto dto)
        {
            var entity = _mapper.Map<Payment>(dto);

            await _paymentRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, PaymentDto dto)
        {
            var existing = await _paymentRepository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Payment not found");

            var entity = _mapper.Map<Payment>(dto);
            entity.Id = id;

            existing.RentalId = dto.RentalId;
            existing.Amount = dto.Amount;

            await _paymentRepository.UpdateAsync(id, existing);
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _paymentRepository.GetByIdAsync(id);
            if (brand == null) return; 

            await _paymentRepository.DeleteAsync(id);
        }
    }
}
