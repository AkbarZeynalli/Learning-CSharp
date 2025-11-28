using Microsoft.EntityFrameworkCore;
using Rent_a_Car_Management_System.Data;
using Rent_a_Car_Management_System.Models;

namespace Rent_a_Car_Management_System.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            _dbSet.Remove(_dbSet.Find(id)!);
            await _context.SaveChangesAsync();
        }

        public  IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Brand brand)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
