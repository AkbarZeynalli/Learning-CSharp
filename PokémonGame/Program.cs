using PokémonGame.Services;
using System;
using System.Collections.Generic;

namespace PokémonGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var operationManagment = new OperationManagment();
            int choice = 0;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to the Pokémon Game!");
                Console.WriteLine("1. Pokémon Category Registration");
                Console.WriteLine("2. Pokémon Ability Registration");
                Console.WriteLine("3. Pokémon Registration");
                Console.WriteLine("4. Gym Registration");
                Console.WriteLine("5. New Trainer Registration");
                Console.WriteLine("6. Trainer Login");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        operationManagment.RegisterCategory();
                        break;
                    case 2:
                        operationManagment.RegisterAbility();
                        break;
                    case 3:
                        operationManagment.PokemonRegister();
                        break;
                    case 4:
                        operationManagment.GymRegister();
                        break;
                    case 5:
                        operationManagment.TrainerRegister();
                        break;
                    case 6:
                        operationManagment.TrainerLogin();
                        break;
                    case 7:
                        Console.WriteLine("Exiting. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Unknown option. Try again.");
                        break;
                }
            } while (choice != 7);
        }
    }
}
 