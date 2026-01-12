using FoodWasteApp.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Services.Interfaces
{
    public interface IFoodItemService
    {
        List<FoodItemDto> GetAll();
        Task<FoodItemDto?> GetByIdAsync(int id);
        Task AddAsync(FoodItemDto dto);
        Task UpdateAsync(FoodItemDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
