namespace Core.Enemies
{
    public interface IEnemy
    {
        float Health { get; }
        float Damage { get; }
        float Speed { get; }
        float AttackRadius { get; }
        float AttackCooldown { get; }

        void Move();
        void Attack();
    }
}