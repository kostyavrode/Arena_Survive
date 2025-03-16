using System;
using Core;
using Core.StateMachine;
using UI.Model;

namespace UI.ViewModel
{
    public class GameOverViewModel
    {
        private readonly GameOverModel _model;
        private readonly GameStateMachine _gameStateMachine;
        private readonly UIManager _uiManager;

        public event Action<float, int> OnGameOverDataChanged;

        public GameOverViewModel(GameOverModel model, GameStateMachine gameStateMachine, UIManager uiManager)
        {
            _model = model;
            _gameStateMachine = gameStateMachine;
            _uiManager = uiManager;

            _model.OnGameOverDataUpdated += (time, kills) => OnGameOverDataChanged?.Invoke(time, kills);
        }

        public void RestartGame()
        {
            _gameStateMachine.ChangeState<PlayingState>();
        }

        public void BackToMenu()
        {
            _gameStateMachine.ChangeState<MenuState>();
        }
    }
}