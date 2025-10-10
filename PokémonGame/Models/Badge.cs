using System;

namespace PokémonGame.Models
{
    internal class Badge : BaseEntity
    {
        public string Name { get; set; }          // Məs: "Daş Rozeti", "Su Rozeti"
        public string Description { get; set; }   // Rozet haqqında qısa məlumat
        public int ExperienceBonus { get; set; }  // Qazandırdığı təcrübə bonusu (məs: 500 XP)

        // Əlaqələr:
        public int GymId { get; set; }
        public Gym Gym { get; set; }              // Bu rozeti hansı Gym verir

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }      // Rozeti kim qazanıb
    }
}
