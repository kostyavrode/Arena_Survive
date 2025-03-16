using System;
using Core;
using Core.StateMachine;
using UnityEditor;
using UnityEngine;
using Zenject;
using PauseState = Core.StateMachine.PauseState;

namespace UI.Model
{
    public class PlayingModel
    {
        public event Action<int> OnScoreChanged;
        public event Action<float> OnTimeUpdated;
        
        private readonly LazyInject<GameStateMachine> _gameStateMachine;
        
        private int _score;
        private float _survivalTime;

        public int Score => _score;
        public float SurvivalTime => _survivalTime;

        public PlayingModel(LazyInject<GameStateMachine> gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void PauseGame()
        {
            _gameStateMachine.Value.ChangeState<PauseState>();
        }

        public void UpdateTimer(float deltaTime)
        {
            _survivalTime += deltaTime;
            OnTimeUpdated?.Invoke(_survivalTime);
        }

        public void AddKill()
        {
            _score++;
            OnScoreChanged?.Invoke(_score);
        }

        public void ResetGame()
        {
            _score = 0;
            _survivalTime = 0;
            OnScoreChanged?.Invoke(_score);
            OnTimeUpdated?.Invoke(_survivalTime);
        }
    }
}