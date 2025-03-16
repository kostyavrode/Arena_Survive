using UnityEngine;

namespace Player
{
    public class PlayerRotator
    {
        private readonly Transform _playerTransform;
        private readonly float _rotationSpeed;

        public PlayerRotator(Transform playerTransform, float rotationSpeed = 10f)
        {
            _playerTransform = playerTransform;
            _rotationSpeed = rotationSpeed;
        }

        public void Rotate(Vector3 direction)
        {
            if (direction == Vector3.zero) return;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _playerTransform.rotation = Quaternion.Slerp(_playerTransform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}