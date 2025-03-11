using System;
using System.IO;
using GameProject.Models;
using GameProject.Services;

namespace GameProject.Controllers
{
    using GameProject.Models;
    using GameProject.Services;
    using System;
    using System.Collections.Generic;

    class GameController
    {
        static List<Character> characters = new List<Character>();
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("1. Create Character");
                Console.WriteLine("2. Save Characters to File");
                Console.WriteLine("3. View Character Stats");
                Console.WriteLine("4. Battle");
                Console.WriteLine("5. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateCharacterMenu();
                        break;
                    case "2":
                        SaveCharactersToFile();
                        break;
                    case "3":
                        ShowCharacterStats();
                        break;
                    case "4":
                        Battle();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        static void CreateCharacterMenu()
        {
            Console.Write("Enter character name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Choose class: Archer, Warrior, Mage");
            string type = Console.ReadLine();

            try
            {
                Character character = CharacterFactory.CreateCharacter(type, name);
                characters.Add(character);
                Console.WriteLine($"Created character {type} named {name}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ShowCharacterStats()
        {
            foreach (var character in characters)
            {
                Console.WriteLine($"{character.GetName()} - {character.GetType().Name} - Level: {character.Level} - HP: {character.GetHealth()}");
            }
        }

        static void Battle()
        {
            if (characters.Count < 2)
            {
                Console.WriteLine("At least 2 characters are required for battle.");
                return;
            }

            Random rand = new Random();
            int index1, index2;

            // Ensure two different characters are chosen
            do
            {
                index1 = rand.Next(characters.Count);
                index2 = rand.Next(characters.Count);
            } while (index1 == index2);

            var fighter1 = characters[index1];
            var fighter2 = characters[index2];

            Console.WriteLine($"{fighter1.GetName()} battles {fighter2.GetName()}");

            while (fighter1.IsAlive() && fighter2.IsAlive())
            {
                fighter1.Attack(fighter2);
                if (fighter2.IsAlive()) fighter2.Attack(fighter1);
            }

            if (fighter1.IsAlive())
            {
                Console.WriteLine($"{fighter1.GetName()} wins!");
                fighter1.LevelUp();
            }
            else
            {
                Console.WriteLine($"{fighter2.GetName()} wins!");
                fighter2.LevelUp();
            }
        }


        static void SaveCharactersToFile()
        {
            string directoryPath = "data";
            Directory.CreateDirectory(directoryPath); // Ensure the 'data' folder exists
            string filePath = Path.Combine(directoryPath, "characters.txt");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var character in characters)
                {
                    writer.WriteLine($"{character.GetName()} - {character.GetType().Name} - Level: {character.Level} - HP: {character.GetHealth()}");
                }
            }
            Console.WriteLine($"Characters have been saved to {filePath}");
        }

    }
}
