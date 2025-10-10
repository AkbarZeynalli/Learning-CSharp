using PokémonGame.Data;
using PokémonGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokémonGame.Repositories
{
    internal class PokemonRepository
    {
        private readonly AppDbContext _context;

        public PokemonRepository()
        {
            _context = new AppDbContext();
        }

        // ✅ Yeni Pokémon əlavə et
        public void Add(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            _context.SaveChanges();
        }

        // ✅ Ad üzrə Pokémon tap (case-insensitive)
        public Pokemon GetByName(string name)
        {
            return _context.Pokemons
                .FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        }

        // ✅ Bütün Pokémon-ları gətir
        public List<Pokemon> GetAll()
        {
            return _context.Pokemons.ToList();
        }

        // ✅ ID üzrə Pokémon tap
        public Pokemon GetById(int id)
        {
            return _context.Pokemons.FirstOrDefault(p => p.Id == id);
        }

        // ✅ Pokémon-u yenilə
        public void Update(Pokemon pokemon)
        {
            var existing = _context.Pokemons.FirstOrDefault(p => p.Id == pokemon.Id);
            if (existing != null)
            {
                existing.Name = pokemon.Name;
                existing.CategoryId = pokemon.CategoryId;
                existing.AbilityId = pokemon.AbilityId;
                existing.Level = pokemon.Level;
                existing.HP = pokemon.HP;

                _context.SaveChanges();
            }
        }

        // ✅ Pokémon-u sil
        public void Delete(Pokemon pokemon)
        {
            _context.Pokemons.Remove(pokemon);
            _context.SaveChanges();
        }
    }
}
