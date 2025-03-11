using System;
using System.IO;
using GameProject.Models;
using GameProject.Services;

namespace GameProject.Services
{
    using GameProject.Models;
    public static class CharacterFactory
    {
        public static Character CreateCharacter(string type, string name)
        {
            return type.ToLower() switch
            {
                "archer" => new Archer(name),
                "warrior" => new Warrior(name),
                "mage" => new Mage(name),
                _ => throw new ArgumentException("Loại nhân vật không hợp lệ!"),
            };
        }
    }
}
