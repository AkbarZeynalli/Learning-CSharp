using System;
using System.Collections.Generic;

namespace PokémonGame.Models
{
    internal class Category : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }
    }

}
