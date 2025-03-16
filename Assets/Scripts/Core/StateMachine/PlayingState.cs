using Core.Spawners;
using Player;

namespace Core.StateMachine
{
    public class PlayingState : IState
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly PlayerFactory _playerFactory;
        
        private PlayerController _playerController;

        public PlayingState (EnemySpawner enemySpawner, PlayerFactory playerFactory)
        {
            _enemySpawner = enemySpawner;
            _playerFactory = playerFactory;
        }

        public void Enter()
        {
            _playerFactory.Create();
            
            _enemySpawner.StartSpawning();
        }

        public void Exit()
        {
            _playerFactory.DestroyPlayer();
            
            _enemySpawner.StopSpawning();
        }
    }
}