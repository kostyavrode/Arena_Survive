using System;
using Core;
using Core.StateMachine;
using UnityEngine;

namespace UI.Model
{
    public class PauseModel
    {
        private readonly GameStateMachine _gameStateMachine;
        private bool _isPaused;

        public bool IsPaused => _isPaused;

        public event Action<bool> OnPauseStateChanged;

        public PauseModel(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void SetPause(bool isPaused)
        {
            _isPaused = isPaused;
            OnPauseStateChanged?.Invoke(_isPaused);

            if (_isPaused)
                _gameStateMachine.ChangeState<PauseState>();
            else
                _gameStateMachine.ChangeState<PlayingState>();
        }

        public void BackToMainMenu()
        {
            _gameStateMachine.ChangeState<MenuState>();
            _isPaused = false;
            OnPauseStateChanged?.Invoke(_isPaused);
        }
    }
}