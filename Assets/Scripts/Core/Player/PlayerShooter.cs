using UnityEngine;

namespace Player
{
    public class PlayerShooter
    {
        private GameObject _bulletPrefab;
        private Transform _shootPoint;

        public PlayerShooter(GameObject bulletPrefab)
        {
            _bulletPrefab = bulletPrefab;
        }

        public void Initialize(Transform shootPoint)
        {
            _shootPoint = shootPoint;
        }

        public void Shoot()
        {
            if (_shootPoint == null)
            {
                Debug.LogError("PlayerShooter: ShootPosition не установлен");
                return;
            }

            Object.Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        }
    }
}