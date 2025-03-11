using System;
using System.IO;
using GameProject.Models;
using GameProject.Services;

using GameProject.Interfaces;

namespace GameProject.Models
{
    public class Warrior : Character
    {
        public Warrior(string name) : base(name, 1, 120, 10, 25) { }
        public override void Attack(IAttackable target)
        {
            Console.WriteLine($"{name} chém {target.GetName()}");
            target.TakeDamage(attackPower);
        }
    }

}
