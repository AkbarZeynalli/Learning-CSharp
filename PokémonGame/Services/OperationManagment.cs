using PokémonGame.Models;
using PokémonGame.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokémonGame.Services
{
    internal class OperationManagment
    {
        private CategoryRepository _categoryRepository;
        private AbilityRepository _abilityRepository;
        private PokemonRepository _pokemonRepository;
        private TrainerRepository _trainerRepository;
        private GymRepository _gymRepository;
        private TrainerLoginRepository _trainerLoginRepository;



        public OperationManagment()
        {
            _categoryRepository = new CategoryRepository();
            _abilityRepository = new AbilityRepository();   
            _pokemonRepository = new PokemonRepository();
            _trainerRepository = new TrainerRepository();
            _gymRepository = new GymRepository();
            _trainerLoginRepository = new TrainerLoginRepository();

        }

        public void RegisterCategory()
        {
            Console.Write("Enter category name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Category name cannot be empty.");
                return;
            }
            if (_categoryRepository.GetByName(name) != null)
            {
                Console.WriteLine("Category already exists.");
                return;
            }
            Console.Write("Enter category description (optional): ");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description)) {
                description = null;
            }

            var category = new Models.Category { Name = name };
            _categoryRepository.Add(category);
            Console.WriteLine("Category registered successfully.");

        }

        public void RegisterAbility()
        {
            Console.Write("Enter ability name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ability name cannot be empty.");
                return;
            }

            if (_abilityRepository.GetByName(name) != null)
            {
                Console.WriteLine("Ability already exists.");
                return;
            }

            Console.Write("Enter ability description (optional): ");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
            {
                description = "No description provided."; // null saxlamaq istəmirsənsə
            }

            var ability = new Models.Ability
            {
                Name = name,
                Description = description
            };

            _abilityRepository.Add(ability);
            Console.WriteLine("Ability registered successfully.");
        }

        public void PokemonRegister()
        {
            var categories = _categoryRepository.GetAll();
            if (categories.Count == 0)
            {
                Console.WriteLine("No categories available. Please register a category first.");
                return;
            }
            var abilities = _abilityRepository.GetAll();
            if (abilities.Count == 0)
            {
                Console.WriteLine("No abilities available. Please register an ability first.");
                return;
            }
            Console.Write("Enter Pokémon name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Pokémon name cannot be empty.");
                return;
            }
            if (_pokemonRepository.GetByName(name) != null)
            {
                Console.WriteLine("Pokémon already exists.");
                return;
            }
            Console.WriteLine("Select a category:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i].Name}");
            }
            if (!int.TryParse(Console.ReadLine(), out int categoryChoice) || categoryChoice < 1 || categoryChoice > categories.Count)
            {
                Console.WriteLine("Invalid category selection.");
                return;
            }
            var selectedCategory = categories[categoryChoice - 1];
            Console.WriteLine("Select an ability:");
            for (int i = 0; i < abilities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {abilities[i].Name}");
            }
            if (!int.TryParse(Console.ReadLine(), out int abilityChoice) || abilityChoice < 1 || abilityChoice > abilities.Count)
            {
                Console.WriteLine("Invalid ability selection.");
                return;
            }
            var selectedAbility = abilities[abilityChoice - 1];
            var pokemon = new Models.Pokemon
            {
                Name = name,
                CategoryId = selectedCategory.Id,
                AbilityId = selectedAbility.Id
            };
            _pokemonRepository.Add(pokemon);
            Console.WriteLine("Pokémon registered successfully.");
        }


        public void TrainerRegister()
        {

            // Add trainer name
            Console.Write("Enter Trainer name: ");
            string trainerName = Console.ReadLine();

            // Show categories right after entering name
            var categories = _categoryRepository.GetAll();
            if (categories.Count == 0)
            {
                Console.WriteLine("No categories found. Please add categories first.");
                return;
            }

            Console.WriteLine("\nSelect a Pokémon category:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i].Name}");
            }

            Console.Write("\nEnter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > categories.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var selectedCategory = categories[choice - 1];

            // Show pokemons from selected category
            var pokemons = _pokemonRepository.GetAll()
                .Where(p => p.CategoryId == selectedCategory.Id)
                .ToList();

            if (pokemons.Count == 0)
            {
                Console.WriteLine("No Pokémon found in this category.");
                return;
            }

            Console.WriteLine($"\nPokémon available in {selectedCategory.Name} category:");
            for (int i = 0; i < pokemons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {pokemons[i].Name}");
            }

            Console.Write("\nSelect your Pokémon: ");
            int pokeChoice;
            if (!int.TryParse(Console.ReadLine(), out pokeChoice) || pokeChoice < 1 || pokeChoice > pokemons.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var selectedPokemon = pokemons[pokeChoice - 1];

            // Give random HP
            Random random = new Random();
            int hp = random.Next(20, 51);

            var trainer = new Trainer
            {
                Name = trainerName,
                StartingPokemonId = selectedPokemon.Id,
                StartingPokemonHP = hp
            };

            _trainerRepository.Add(trainer);

            Console.WriteLine($"\nTrainer '{trainerName}' registered successfully!");
            Console.WriteLine($"Selected Pokémon: {selectedPokemon.Name} (HP: {hp})");
        }

        public void GymRegister()
        {
            Console.Write("Enter Gym name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Gym name cannot be empty.");
                return;
            }

            if (_gymRepository.GetByName(name) != null)
            {
                Console.WriteLine("Gym already exists.");
                return;
            }

            Console.Write("Enter Gym location (optional): ");
            string location = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(location))
            {
                location = null;
            }

            Console.Write("Enter Gym leader name: ");
            string leader = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(leader))
            {
                leader = "Unknown Leader"; // boş buraxılsa default dəyər ver
            }

            Console.Write("Enter Gym description: ");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description))
            {
                description = "No description provided.";
            }

            var gym = new Models.Gym
            {
                Name = name,
                Location = location,
                Leader = leader,
                Description = description
            };

            _gymRepository.Add(gym);
            Console.WriteLine("Gym registered successfully.");
        }

        public void TrainerLogin()
        {
            Console.Write("Enter Trainer name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Trainer name cannot be empty.");
                return;
            }

            var trainer = _trainerLoginRepository.GetByName(name);

            if (trainer == null)
            {
                Console.WriteLine("Trainer not found. Please register first.");
                return;
            }

            Console.WriteLine($"Welcome back, {trainer.Name}!");

            if (trainer.Pokemons == null || !trainer.Pokemons.Any())
            {
                Console.WriteLine("You don't have any Pokémon yet.");
            }
            else
            {
                Console.WriteLine("Your Pokémon list:");
                int i = 1;
                foreach (var pokemon in trainer.Pokemons)
                {
                    Console.WriteLine($"{i++}. {pokemon.Name}");
                }
            }
        }
    }
}
