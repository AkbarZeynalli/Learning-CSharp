using System.Collections.Generic;

namespace PokémonGame.Models
{
    internal class Gym : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        // Added to match usage in GymRepository
        public string Location { get; set; }
        public string Leader { get; set; }

        // Gym-də döyüşən təlimçilər (Trainer-lərlə əlaqə)
        public ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();
    }
}
