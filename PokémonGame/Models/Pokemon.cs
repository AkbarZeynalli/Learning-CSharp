using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonGame.Models
{
    internal class Pokemon : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int HP { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int AbilityId { get; set; }
        public Ability Ability { get; set; }
    }

}
