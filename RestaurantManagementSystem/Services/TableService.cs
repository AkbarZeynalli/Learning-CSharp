using RestaurantManagementSystem.Dtos;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repository;
using RestaurantManagementSystem.Services.Interfaces;

namespace RestaurantManagementSystem.Services
{
    public class TableService : ITableService
    {
        private readonly IGenericRepository<Table> _tableRepository;

        public TableService(IGenericRepository<Table> tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public async Task<List<TableDto>> GetAllAsync()
        {
            var tables = await _tableRepository.GetAllAsync();

            return tables.Select(t => new TableDto
            {
                Id = t.Id,
                TableNumber = t.TableNumber,
                Capacity = t.Capacity,
                IsOccupied = t.IsAvailable
            }).ToList();
        }

        public async Task<TableDto?> GetByIdAsync(int id)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table == null) return null;

            return new TableDto
            {
                Id = table.Id,
                TableNumber = table.TableNumber,
                Capacity = table.Capacity,
                IsOccupied = table.IsAvailable
            };
        }

        public async Task AddAsync(TableDto dto)
        {
            var table = new Table
            {
                TableNumber = dto.TableNumber,
                Capacity = dto.Capacity,
                IsAvailable = dto.IsOccupied
            };

            await _tableRepository.AddAsync(table);
        }

        public async Task UpdateAsync(int id, TableDto dto)
        {
            var table = await _tableRepository.GetByIdAsync(id);
            if (table == null) return;

            table.TableNumber = dto.TableNumber;
            table.Capacity = dto.Capacity;
            table.IsAvailable = dto.IsOccupied;

            await _tableRepository.UpdateAsync(table);
        }

        public async Task DeleteAsync(int id)
        {
            await _tableRepository.DeleteAsync(id);
        }
    }
}
