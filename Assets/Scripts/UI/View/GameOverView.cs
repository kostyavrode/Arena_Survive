using System;
using Core;
using TMPro;
using UI.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class GameOverView : View<GameOverViewModel>
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;
        [SerializeField] private TMP_Text survivalTimeText;
        [SerializeField] private TMP_Text killsText;

        private void Awake()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }

        private void Initialize()
        {
            restartButton.onClick.AddListener(() => ViewModel.RestartGame());
            menuButton.onClick.AddListener(() => ViewModel.BackToMenu());

            ViewModel.OnGameOverDataChanged += UpdateUI;
        }

        private void Dispose()
        {
            restartButton.onClick.RemoveAllListeners();
            menuButton.onClick.RemoveAllListeners();

            ViewModel.OnGameOverDataChanged -= UpdateUI;
        }

        public void UpdateUI(float survivalTime, int kills)
        {
            survivalTimeText.text = $"Время: {survivalTime:F1} сек.";
            killsText.text = $"Убийств: {kills}";
        }
    }
}