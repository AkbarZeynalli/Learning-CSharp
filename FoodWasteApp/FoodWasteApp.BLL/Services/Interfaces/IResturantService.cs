using FoodWasteApp.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Services.Interfaces
{
    public interface IResturantService
    {
        List<RestaurantDto> GetAll();
        Task<RestaurantDto?> GetByIdAsync(int id);
        Task AddAsync(RestaurantDto dto);
        Task UpdateAsync(RestaurantDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
