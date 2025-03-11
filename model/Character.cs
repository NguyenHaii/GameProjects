using System;
using System.IO;
using GameProject.Models;
using GameProject.Services;


namespace GameProject.Models
{
    using GameProject.Interfaces;
    public abstract class Character : IAttackable
    {
        protected string name;
        protected int level;
        protected int health;
        protected int defense;
        protected int attackPower;


        public Character(string name, int level, int health, int defense, int attackPower)
        {
            this.name = name;
            this.level = level;
            this.health = health;
            this.defense = defense;
            this.attackPower = attackPower;
        }
        public bool IsAlive() => health > 0;
        public void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(damage - defense, 0);
            health -= actualDamage;
            if (health < 0) health = 0;
            Console.WriteLine($"{name} nhận {actualDamage} sát thương, còn {health} HP.");
        }
        public int Level => level; // Thêm thuộc tính Level để lấy giá trị cấp độ

        public int GetHealth() => health;
        public string GetName() => name;
        public void LevelUp()
        {
            level++;
            health += 10;
            attackPower += 5;
            defense += 2;
            Console.WriteLine($"{name} đã lên cấp {level}! HP tăng lên {health}, tấn công {attackPower}, phòng thủ {defense}.");
        }
        public abstract void Attack(IAttackable target);
    }
}
