using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Class <c>Menu</c> represents the in-game menu and user interaction logic.
    /// It allows users to select a race and generate units and buildings.
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Displays the menu with available race options.
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("Welcome to the game! Select one of the races below by choosing a number. ");
            Console.WriteLine("1. Human Race");
            Console.WriteLine("2. Dwarf Race");
            Console.WriteLine("3. Elf Race");
            Console.WriteLine("4. Exit.");
        }

        /// <summary>
        /// Handles user input and processes the selected options.
        /// </summary>
        public void HandleUserInput()
        {
            ShowMenu();
            Console.WriteLine("Insert the number of the option you want: ");
            var player = new Player();
            var opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1: player.ChooseRace(Race.human);
                    break;
                case 2: player.ChooseRace(Race.dwarf);
                    break;
                case 3: player.ChooseRace(Race.elf);
                    break;
                case 4: Environment.Exit(0);
                    break;
                default: Console.WriteLine("Invalid option!"); 
                    break;
            }
            if (player.GetCurrentRaceFactory().Equals(null))
            {
                return;
            }
            HandleWorldGenerate(player);
        }

        /// <summary>
        /// Handles the generation of units and buildings based on user input.
        /// </summary>
        /// <param name="player">The player object representing the selected race.</param>
        public void HandleWorldGenerate(Player player)
        {
            Console.WriteLine("Select the name of the unit: ");
            var name = Console.ReadLine();
            Console.WriteLine("Select the damage of the unit: ");
            double.TryParse(Console.ReadLine(), out double damage);
            Console.WriteLine("Select the time needed for the building to be made: ");
            int.TryParse(Console.ReadLine(), out int time);
            player.GenerateWorld(name, damage, time);
        }
    }
}
