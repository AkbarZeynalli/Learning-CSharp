using Rent_a_Car_Management_System.Models;

namespace Rent_a_Car_Management_System.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(Brand brand);
        Task UpdateAsync(Rental rental);
    }
}
