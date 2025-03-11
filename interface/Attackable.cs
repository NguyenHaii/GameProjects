namespace GameProject.Interfaces
{
    public interface IAttackable
    {
        void Attack(IAttackable target);
        string GetName();
        int GetHealth();
        bool IsAlive();
        void LevelUp();
        void TakeDamage(int attackPower);
    }
}