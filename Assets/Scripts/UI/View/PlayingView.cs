using TMPro;
using UI.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class PlayingView : View<PlayingViewModel>
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private Button _pauseButton;

        public override void Initialize()
        {
            _pauseButton.onClick.AddListener(() => ViewModel.OnPauseGame());
            ViewModel.ScoreUpdated += score => _scoreText.text = $"Score: {score}";
            ViewModel.TimeUpdated += time => _timerText.text = $"Time: {time:F1}";
        }

        public override void Dispose()
        {
            _pauseButton.onClick.RemoveAllListeners();
            ViewModel.ScoreUpdated -= score => _scoreText.text = $"Score: {score}";
            ViewModel.TimeUpdated -= time => _timerText.text = $"Time: {time:F1}";
        }

        private void Update()
        {
            //ViewModel.UpdateTimer(Time.deltaTime);
        }
    }
}