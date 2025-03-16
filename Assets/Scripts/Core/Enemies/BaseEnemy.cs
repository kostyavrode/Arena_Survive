using Core.EntitiesInterfaces;
using Player;
using UnityEngine;
using Zenject;

namespace Core.Enemies
{
    public abstract class BaseEnemy : MonoBehaviour, IEnemy, IDamageable
    {
        [SerializeField] protected float health;
        [SerializeField] protected float damage;
        [SerializeField] protected float speed;
        [SerializeField] protected float attackRadius;
        [SerializeField] protected float attackCooldown;

        public Transform _target;

        public float Health => health;
        public float Damage => damage;
        public float Speed => speed;
        public float AttackRadius => attackRadius;
        public float AttackCooldown => attackCooldown;

        protected virtual void Update()
        {
            Move();
        }

        public abstract void Move();
        public abstract void Attack();

        public void TakeDamage(int damageAmount)
        {
            health -= damageAmount;
            if (health <= 0)
            {
                Die();
            }
        }

        protected void Die()
        {
            Destroy(gameObject);
        }
    }
}