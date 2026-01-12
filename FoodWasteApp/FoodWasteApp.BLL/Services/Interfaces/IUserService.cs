using FoodWasteApp.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        Task<UserDto?> GetByIdAsync(int id);
        Task AddAsync(UserDto dto);
        Task UpdateAsync(UserDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
