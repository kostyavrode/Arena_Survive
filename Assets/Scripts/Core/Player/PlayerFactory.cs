using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerFactory : IFactory<PlayerController>
    {
        private readonly DiContainer _container;
        private readonly GameObject _playerPrefab;
        
        private PlayerController _playerInstance;

        public PlayerFactory(DiContainer container, GameObject playerPrefab)
        {
            _container = container;
            _playerPrefab = playerPrefab;
        }

        public PlayerController Create()
        {
            if (_playerInstance != null) return _playerInstance;

            _playerInstance = _container.InstantiatePrefabForComponent<PlayerController>(
                _playerPrefab, PlayerSpawnPoint.SpawnPosition, Quaternion.identity, null);

            return _playerInstance;
        }
        
        public void DestroyPlayer()
        {
            if (_playerInstance != null)
            {
                Object.Destroy(_playerInstance.gameObject);
                _playerInstance = null;
            }
        }
    }
}