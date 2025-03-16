using System.Collections.Generic;
using Core.Spawners;

namespace Core.StateMachine
{
    public class PauseState : IState
    {
        private readonly EnemySpawner _enemySpawner;

        public PauseState(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }

        public void Enter()
        {
            _enemySpawner.PauseSpawning();
        }

        public void Exit()
        {
            _enemySpawner.ResumeSpawning();
        }
    }
}