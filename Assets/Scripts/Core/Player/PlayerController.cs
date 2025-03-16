using Core;
using Core.EntitiesInterfaces;
using Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerController : MonoBehaviour, IDamageable, IMoveable
    {
        private GameStateMachine _gameStateMachine;
        
        private PlayerInput _input;
        private PlayerMover _mover;
        private PlayerRotator _rotator;
        private PlayerShooter _shooter;
        private PlayerHealth _health;
        
        private CharacterController _characterController;
        
        [SerializeField] private Transform _shootPosition;
        [SerializeField] private GameObject _bulletPrefab;
        
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _moveSpeed;

        [Inject]
        public void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            
            _input = new PlayerInput();
            _mover = new PlayerMover(_characterController, _moveSpeed);
            _rotator = new PlayerRotator(transform);
            _shooter = new PlayerShooter(_bulletPrefab);
            
            _shooter.Initialize(_shootPosition);
            
            _health = new PlayerHealth(_maxHealth, this);
        }

        private void Update()
        {
            Vector3 movementInput = _input.GetMovementInput();
            Move(movementInput);

            if (_input.GetFireButtonStatus())
            {
                _shooter.Shoot();
            }
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        public void Move(Vector3 direction)
        {
            _mover.Move(direction);
            _rotator.Rotate(direction);
        }
        
        public void Death()
        {
            _gameStateMachine.ChangeState<GameOverState>();
        }
        
    }
}