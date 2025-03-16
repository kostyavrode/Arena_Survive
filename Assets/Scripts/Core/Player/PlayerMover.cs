using UnityEngine;

namespace Player
{
    public class PlayerMover
    {
        private readonly CharacterController _characterController;
        private readonly float _moveSpeed;
        private readonly float _gravity = -9.81f;
        private Vector3 _velocity;

        public PlayerMover(CharacterController characterController, float moveSpeed = 5f)
        {
            _characterController = characterController;
            _moveSpeed = moveSpeed;
        }

        public void Move(Vector3 direction)
        {
            Vector3 move = _characterController.transform.right * direction.x +
                           _characterController.transform.forward * direction.z;

            _characterController.Move(move * _moveSpeed * Time.deltaTime);
            
            if (!_characterController.isGrounded)
            {
                _velocity.y += _gravity * Time.deltaTime;
                _characterController.Move(_velocity * Time.deltaTime);
            }
            else
            {
                _velocity.y = 0;
            }
        }
    }
}