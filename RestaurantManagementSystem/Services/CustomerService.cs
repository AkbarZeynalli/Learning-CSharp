using RestaurantManagementSystem.Dtos;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repository;
using RestaurantManagementSystem.Services.Interfaces;
using System.Numerics;

namespace RestaurantManagementSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerService;
        public CustomerService(IGenericRepository<Customer> customerService)
        {
            _customerService = customerService;
        }

        public async Task<List<CustomerDto>> GetAllAsync()
        {
            var customer = await _customerService.GetAllAsync();

            return customer.Select(c => new CustomerDto
            {
                Id = c.Id,
                FullName = c.FullName,
                PhoneNumber = c.Phone,
                Email = c.Email
            }).ToList();
        }
        public async Task<CustomerDto> GetByIdAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return null;
            return new CustomerDto
            {
                Id = customer.Id,
                FullName = customer.FullName,
                PhoneNumber = customer.Phone,
                Email = customer.Email
            };
        }
        public async Task AddAsync(CustomerDto dto)
        {
            var customer = new Customer
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Phone = dto.PhoneNumber,
                Email = dto.Email
            };
            await _customerService.AddAsync(customer);
        }
        public async Task UpdateAsync(int id, CustomerDto dto)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
                return;
            customer.Id = dto.Id;
            customer.FullName = dto.FullName;
            customer.Phone = dto.PhoneNumber;
            customer.Email = dto.Email;
            await _customerService.UpdateAsync(customer);
        }
        public async Task DeleteAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return;
            await _customerService.DeleteAsync(id);
        }
    }
}
