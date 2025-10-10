using PokémonGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokémonGame.Repositories
{
    internal class GymRepository
    {
        private readonly AppDbContext _context;

        public GymRepository()
        {
            _context = new AppDbContext();
        }

        public GymRepository(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Yeni Gym əlavə et
        public void Add(Models.Gym gym)
        {
            _context.Gyms.Add(gym);
            _context.SaveChanges();
        }

        // ✅ Adla Gym tap
        public Models.Gym GetByName(string name)
        {
            return _context.Gyms
                .AsEnumerable()
                .FirstOrDefault(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }


        // ✅ Bütün Gym-ləri gətir
        public List<Models.Gym> GetAll()
        {
            return _context.Gyms.ToList();
        }

        // ✅ ID ilə Gym tap
        public Models.Gym GetById(int id)
        {
            return _context.Gyms.FirstOrDefault(g => g.Id == id);
        }

        // ✅ Gym sil
        public void Delete(int id)
        {
            var gym = _context.Gyms.FirstOrDefault(g => g.Id == id);
            if (gym != null)
            {
                _context.Gyms.Remove(gym);
                _context.SaveChanges();
            }
        }

        // ✅ Gym yenilə
        public void Update(Models.Gym updatedGym)
        {
            var gym = _context.Gyms.FirstOrDefault(g => g.Id == updatedGym.Id);
            if (gym != null)
            {
                gym.Name = updatedGym.Name;
                gym.Location = updatedGym.Location;
                gym.Leader = updatedGym.Leader;
                _context.SaveChanges();
            }
        }
    }
}
