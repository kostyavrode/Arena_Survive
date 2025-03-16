using UnityEngine;

namespace Core.Bullets
{
    public interface IBullet
    {
        float Speed { get; }
        int Damage { get; }
        void Shoot(Vector3 direction);
    }
}