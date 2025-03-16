using System.Collections;
using System.Collections.Generic;
using Core.Spawners;
using UI;
using UI.Model;
using Zenject;

namespace Core.StateMachine
{
    public class PlayingState : IState
    {
        private readonly LazyInject<GameStateMachine> _gameStateMachine;
        private readonly UIManager _uiManager;
        private readonly EnemySpawner _enemySpawner;
        private readonly PlayingModel _playingModel;

        public PlayingState(LazyInject<GameStateMachine> gameStateMachine, UIManager uiManager, EnemySpawner enemySpawner, PlayingModel playingModel)
        {
            _gameStateMachine = gameStateMachine;
            _uiManager = uiManager;
            _enemySpawner = enemySpawner;
            _playingModel = playingModel;
        }

        public void Enter()
        {
            _enemySpawner.StartSpawning();
        }

        public void Exit()
        {
            
        }

        public void Update(float deltaTime)
        {
            _playingModel.UpdateTimer(deltaTime);
        }

        public void OnEnemyKilled()
        {
            _playingModel.AddKill();
        }

        public void OnPlayerDied()
        {
            _gameStateMachine.Value.ChangeState<GameOverState>();
        }
    }
}