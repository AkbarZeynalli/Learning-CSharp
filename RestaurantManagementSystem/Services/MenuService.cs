using RestaurantManagementSystem.Dtos;
using RestaurantManagementSystem.Models;
using RestaurantManagementSystem.Repository;
using RestaurantManagementSystem.Services.Interfaces;

namespace RestaurantManagementSystem.Services
{
    public class MenuService : IMenuService
    {
        private readonly IGenericRepository<MenuItem> _menuRepository;

        public MenuService(IGenericRepository<MenuItem> menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<List<MenuItemDto>> GetAllAsync()
        {
            var items = await _menuRepository.GetAllAsync();

            return items.Select(m => new MenuItemDto
            {
                Id = m.Id,
                ItemName = m.Name,
                Price = m.Price,
                Category = m.Category
            }).ToList();
        }

        public async Task<MenuItemDto> GetByIdAsync(int id)
        {
            var menuItem = await _menuRepository.GetByIdAsync(id);
            if (menuItem == null)
                return null;

            return new MenuItemDto
            {
                Id = menuItem.Id,
                ItemName = menuItem.Name,
                Price = menuItem.Price,
                Category = menuItem.Category
            };
        }

        public async Task AddAsync(MenuItemDto dto)
        {
            var item = new MenuItem
            {
                Name = dto.ItemName,
                Price = dto.Price,
                Category = dto.Category
            };

            await _menuRepository.AddAsync(item);
        }

        public async Task UpdateAsync(int id, MenuItemDto dto)
        {
            var item = await _menuRepository.GetByIdAsync(id);
            if (item == null) return;

            item.Name = dto.ItemName;
            item.Price = dto.Price;
            item.Category = dto.Category;

            await _menuRepository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _menuRepository.GetByIdAsync(id);
            if (item == null) return;

            await _menuRepository.DeleteAsync(id);
        }
    }
}
