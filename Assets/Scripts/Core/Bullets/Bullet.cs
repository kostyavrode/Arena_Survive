using Core.EntitiesInterfaces;
using UnityEngine;

namespace Core.Bullets
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private int damage = 10;
        private Vector3 _direction;

        public float Speed => speed;
        public int Damage => damage;

        public void Shoot(Vector3 direction)
        {
            _direction = direction.normalized;
            Destroy(gameObject, 5f);
        }

        private void Update()
        {
            transform.position += _direction * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                damageable.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}