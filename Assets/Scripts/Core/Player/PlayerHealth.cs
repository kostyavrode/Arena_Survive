using Core;
using Core.StateMachine;
using UI;
using UI.View;
using UnityEngine;

namespace Player
{
    public class PlayerHealth
    {
        private readonly PlayerController _playerController;
        
        private int _currentHealth;
        private readonly int _maxHealth;

        public PlayerHealth(int maxHealth, PlayerController playerController)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
            
            _playerController = playerController;
        }

        public void TakeDamage(int amount)
        {
            _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, _maxHealth);
            
            Debug.Log("Player hp"+_currentHealth);

            if (_currentHealth == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("Player Dead");
            _playerController.Death();
        }
    }
}