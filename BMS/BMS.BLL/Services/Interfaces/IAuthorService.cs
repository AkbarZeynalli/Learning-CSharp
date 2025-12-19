using BMS.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS.BLL.Services.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorDto> GetAll();
        Task<AuthorDto?> GetByIdAsync(int id);
        Task AddAsync(AuthorDto dto);
        Task UpdateAsync(AuthorDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
