using PokémonGame.Data;
using System.Linq;

namespace PokémonGame.Repositories
{
    internal class TrainerLoginRepository
    {
        private readonly AppDbContext _context;

        public TrainerLoginRepository()
        {
            _context = new AppDbContext();
        }

        // ✅ Adla trainer tapmaq (login üçün)
        public Models.Trainer GetByName(string name)
        {
            return _context.Trainers
                .FirstOrDefault(t => t.Name.ToLower() == name.ToLower());
        }
    }
}
