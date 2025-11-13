using RestaurantManagementSystem.Dtos;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repository;
using RestaurantManagementSystem.Services.Interfaces;

namespace RestaurantManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _employeeRepository;

        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employee = await _employeeRepository.GetAllAsync();

            return employee.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FullName = e.FullName,
                Position = e.Position,
                Salary = e.Salary
            }).ToList();
        }
        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                return null;
            return new EmployeeDto
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Position = employee.Position,
                Salary = employee.Salary
            };
        }
        public async Task AddAsync(EmployeeDto dto)
        {
            var employee = new Employee
            {
                Id = dto.Id,
                FullName = dto.FullName,
                Position = dto.Position,
                Salary = dto.Salary
            };
            await _employeeRepository.AddAsync(employee);
        }
        public async Task UpdateAsync(int id, EmployeeDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if(employee == null) return;
            employee.Id = dto.Id;
            employee.FullName = dto.FullName;
            employee.Position = dto.Position;
            employee.Salary = dto.Salary;
            await _employeeRepository.UpdateAsync(employee);
        }
        public async Task DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return;
            await _employeeRepository.DeleteAsync(id);
        }
    }
}
