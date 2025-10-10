using PokémonGame.Data;
using PokémonGame.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokémonGame.Repositories
{
    internal class AbilityRepository
    {
        private readonly AppDbContext _context;

        public AbilityRepository()
        {
            _context = new AppDbContext();
        }

        // ✅ Ability əlavə et
        public void Add(Ability ability)
        {
            _context.Abilities.Add(ability);
            _context.SaveChanges();
        }

        // ✅ Bütün abilities-i gətir
        public List<Ability> GetAll()
        {
            return _context.Abilities.ToList();
        }

        // ✅ Ad üzrə Ability tap
        public Ability GetByName(string name)
        {
            return _context.Abilities.FirstOrDefault(a => a.Name.ToLower() == name.ToLower());
        }

        // ✅ ID üzrə Ability tap
        public Ability GetById(int id)
        {
            return _context.Abilities.FirstOrDefault(a => a.Id == id);
        }

        // ✅ Ability sil
        public void Delete(int id)
        {
            var ability = _context.Abilities.FirstOrDefault(a => a.Id == id);
            if (ability != null)
            {
                _context.Abilities.Remove(ability);
                _context.SaveChanges();
            }
        }

        // ✅ Ability yenilə
        public void Update(Ability updated)
        {
            var ability = _context.Abilities.FirstOrDefault(a => a.Id == updated.Id);
            if (ability != null)
            {
                ability.Name = updated.Name;
                ability.Description = updated.Description;
                _context.SaveChanges();
            }
        }
    }
}
