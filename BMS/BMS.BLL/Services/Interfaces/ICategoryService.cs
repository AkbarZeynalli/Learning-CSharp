using BMS.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task AddAsync(CategoryDto dto);
        Task UpdateAsync(CategoryDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
