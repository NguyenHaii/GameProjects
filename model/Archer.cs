using System;
using System.IO;
using GameProject.Models;
using GameProject.Services;
using GameProject.Interfaces;

namespace GameProject.Models
{
    public class Archer : Character
    {
        public Archer(string name) : base(name, 1, 80, 5, 20) { }
        public override void Attack(IAttackable target)
        {
            Console.WriteLine($"{name} bắn tên vào {target.GetName()}");
            target.TakeDamage(attackPower);
        }
    }
}