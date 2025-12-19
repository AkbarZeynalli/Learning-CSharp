using BMS.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BLL.Services.Interfaces
{
    public interface IBookService
    {
        List<BookDto> GetAll();
        Task<BookDto?> GetByIdAsync(int id);
        Task AddAsync(BookDto dto);
        Task UpdateAsync(BookDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
