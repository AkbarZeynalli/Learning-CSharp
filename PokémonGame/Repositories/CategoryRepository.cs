using PokémonGame.Data;
using PokémonGame.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokémonGame.Repositories
{
    internal class CategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository()
        {
            _context = new AppDbContext();
        }

        // ✅ Yeni kateqoriya əlavə et
        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        // ✅ Bütün kateqoriyaları gətir
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        // ✅ Ad üzrə kateqoriyanı tap
        public Category GetByName(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }

        // ✅ ID üzrə kateqoriyanı tap
        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        // ✅ Kateqoriyanı sil
        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        // ✅ Kateqoriyanı yenilə
        public void Update(Category updatedCategory)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == updatedCategory.Id);
            if (category != null)
            {
                category.Name = updatedCategory.Name;
                category.Description = updatedCategory.Description;
                _context.SaveChanges();
            }
        }
    }
}
