using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rent_a_Car_Management_System.Dots;
using Rent_a_Car_Management_System.Models;
using Rent_a_Car_Management_System.Repository;
using Rent_a_Car_Management_System.Services.Interfaces;

namespace Rent_a_Car_Management_System.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAll().ToListAsync();

            var dtos = _mapper.Map<List<CustomerDto>>(customers);
            return dtos;
        }

        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null) return null;

            var dto = _mapper.Map<CustomerDto>(customer);
            return dto;
        }

        public async Task AddAsync(CustomerDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);

            await _customerRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, CustomerDto dto)
        {
            var existing = await _customerRepository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Customer not found");


            var entity = _mapper.Map<Customer>(dto);
            entity.Id = id;

            await _customerRepository.UpdateAsync(id, existing);
        }

        public async Task DeleteAsync(int id)
        {
            var brand = await _customerRepository.GetByIdAsync(id);
            if (brand == null) return;

            await _customerRepository.DeleteAsync(id);
        }
    }
}
