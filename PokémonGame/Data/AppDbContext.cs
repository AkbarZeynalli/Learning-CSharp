using Microsoft.EntityFrameworkCore;
using PokémonGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PokémonGame.Data
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=DESKTOP-H6VMCSI\\SQLEXPRESS;Initial Catalog=PokemonGameDB;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Badge> Badges { get; set; }

    }
}