using PokémonGame.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonGame.Repositories
{
    internal class TrainerRepository
    {
        private readonly AppDbContext _context;
        public TrainerRepository()
        {
            _context = new AppDbContext();
        }
        public void Add(Models.Trainer trainer)
        {
            _context.Trainers.Add(trainer);
            _context.SaveChanges();
        }
        public Models.Trainer GetByUsername(string username)
        {
            // Replace 'Username' with 'Name' since Trainer does not have a 'Username' property.
            return _context.Trainers.FirstOrDefault(t => t.Name == username);
        }
        public Models.Trainer GetById(int id)
        {
            return _context.Trainers.FirstOrDefault(t => t.Id == id);
        }

        public List<Models.Trainer> GetAll()
        {
            return _context.Trainers.ToList();
        }

        public void Update(Models.Trainer trainer)
        {
            _context.Trainers.Update(trainer);
            _context.SaveChanges();
        }
        public void Delete(Models.Trainer trainer)
        {
            _context.Trainers.Remove(trainer);
            _context.SaveChanges();
        }
    }
}
