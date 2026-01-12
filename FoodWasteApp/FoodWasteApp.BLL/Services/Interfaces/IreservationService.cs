using FoodWasteApp.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWasteApp.BLL.Services.Interfaces
{
    public interface IReservationService
    {
        List<ReservationDto> GetAll();
        Task<ReservationDto?> GetByIdAsync(int id);
        Task AddAsync(ReservationDto dto);
        Task UpdateAsync(ReservationDto dto);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
