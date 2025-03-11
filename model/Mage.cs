using System;
using System.IO;
using GameProject.Models;
using GameProject.Services;

using GameProject.Interfaces;

namespace GameProject.Models
{
    public class Mage : Character
    {
        public Mage(string name) : base(name, 1, 70, 3, 30) { }
        public override void Attack(IAttackable target)
        {
            Console.WriteLine($"{name} tung phép thuật vào {target.GetName()}");
            target.TakeDamage(attackPower);
        }
    }
}



