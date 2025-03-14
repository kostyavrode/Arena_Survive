using System;
using UI.Model;
using UI.View;

namespace UI.ViewModel
{
    public class PlayingViewModel
    {
        private readonly PlayingModel _model;
        private readonly UIManager _uiManager;

        public event Action<int> ScoreUpdated;
        public event Action<float> TimeUpdated;

        public PlayingViewModel(PlayingModel model, UIManager uiManager)
        {
            _model = model;
            _uiManager = uiManager;

            _model.OnScoreChanged += score => ScoreUpdated?.Invoke(score);
            _model.OnTimeUpdated += time => TimeUpdated?.Invoke(time);
        }

        public void OnPauseGame()
        {
            _uiManager.OpenWindow<PauseView>();
        }

        public void AddScore(int amount)
        {
            _model.AddScore(amount);
        }

        public void UpdateTimer(float deltaTime)
        {
            _model.UpdateTimer(deltaTime);
        }
    }
}