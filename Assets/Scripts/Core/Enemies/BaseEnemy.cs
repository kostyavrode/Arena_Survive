using UnityEngine;

namespace Core.Enemies
{
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField] protected float health;
        [SerializeField] protected float damage;
        [SerializeField] protected float speed;
        [SerializeField] protected float attackRadius;
        [SerializeField] protected float attackCooldown;

        protected Transform player;

        public float Health => health;
        public float Damage => damage;
        public float Speed => speed;
        public float AttackRadius => attackRadius;
        public float AttackCooldown => attackCooldown;

        protected virtual void Start()
        {
            player = GameObject.FindWithTag("Player")?.transform;
        }

        protected virtual void Update()
        {
            Move();
        }

        public abstract void Move();
        public abstract void Attack();

        public void TakeDamage(float amount)
        {
            health -= amount;
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