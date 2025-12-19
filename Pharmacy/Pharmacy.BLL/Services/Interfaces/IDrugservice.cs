using Pharmacy.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.BLL.Services.Interfaces
{
    public interface IDrugservice
    {
        List<DrugDto> GetAll();
        Task<DrugDto?> GetByIdAsync(int id);
        Task AddAsync(DrugDto dto);
        Task UpdateAsync(DrugDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
