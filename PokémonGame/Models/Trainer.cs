using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonGame.Models
{
    internal class Trainer : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Pokemon> Pokemons { get; set; }
        public ICollection<Badge> Badges { get; set; }
        public int Gold { get; set; }
        public int PokemonId { get; internal set; }
        public int StartingPokemonId { get; internal set; }
        public int StartingPokemonHP { get; internal set; }
    }

}
