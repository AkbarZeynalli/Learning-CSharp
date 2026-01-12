using FoodWasteApp.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Services.Interfaces
{
    public interface IReviewService
    {
        List<ReviewDto> GetAll();
        Task<ReviewDto?> GetByIdAsync(int id);
        Task AddAsync(ReviewDto dto);
        Task UpdateAsync(ReviewDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
