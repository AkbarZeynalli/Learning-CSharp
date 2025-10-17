using LibraryGenericRepository.Repositories;
using LibraryManagamentSistem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SManagmentSystem.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        // Default ctor - creates a new context (keeps original behavior)
        public GenericRepository()
            : this(new AppDbContext())
        {
        }

        // Overload to allow DI or reusing existing context in tests
        public GenericRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _dbSet.Add(entity);
            _context.SaveChanges();
            Console.WriteLine($"{typeof(T).Name} added successfully.");
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                Console.WriteLine($"{typeof(T).Name} with id {id} not found. Delete aborted.");
                return;
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();
            Console.WriteLine($"{typeof(T).Name} deleted successfully.");
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            try
            {
                // Attach if detached to ensure EF Core tracks the entity
                var entry = _context.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }

                entry.State = EntityState.Modified;
                _context.SaveChanges();
                Console.WriteLine($"{typeof(T).Name} updated successfully.");
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.WriteLine($"{typeof(T).Name} update failed due to concurrency issue.");
                throw;
            }
        }
    }
}
