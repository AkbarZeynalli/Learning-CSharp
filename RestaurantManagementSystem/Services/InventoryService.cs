using RestaurantManagementSystem.Dtos;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repository;
using RestaurantManagementSystem.Services.Interfaces;

namespace RestaurantManagementSystem.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IGenericRepository<Inventory> _inventoryRepository;

        public InventoryService(IGenericRepository<Inventory> inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<List<InventoryDto>> GetAllAsync()
        {
            var items = await _inventoryRepository.GetAllAsync();

            return items.Select(i => new InventoryDto
            {
                Id = i.Id,
                ItemName = i.Name,
                Quantity = i.Quantity,
                Unit = i.Unit
            }).ToList();
        }

        public async Task<InventoryDto> GetByIdAsync(int id)
        {
            var item = await _inventoryRepository.GetByIdAsync(id);
            if (item == null)
                return null;

            return new InventoryDto
            {
                Id = item.Id,
                ItemName = item.Name,
                Quantity = item.Quantity,
                Unit = item.Unit
            };
        }

        public async Task AddAsync(InventoryDto dto)
        {
            var inventory = new Inventory
            {
                Name = dto.ItemName,
                Quantity = dto.Quantity,
                Unit = dto.Unit
            };

            await _inventoryRepository.AddAsync(inventory);
        }

        public async Task UpdateAsync(int id, InventoryDto dto)
        {
            var item = await _inventoryRepository.GetByIdAsync(id);
            if (item == null) return;

            item.Name = dto.ItemName;
            item.Quantity = dto.Quantity;
            item.Unit = dto.Unit;

            await _inventoryRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _inventoryRepository.GetByIdAsync(id);
            if (item == null) return;

            await _inventoryRepository.DeleteAsync(id);
        }
    }
}
