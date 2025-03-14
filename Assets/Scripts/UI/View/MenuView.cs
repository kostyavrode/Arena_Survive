using System;
using UI.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class MenuView : View<MenuViewModel>
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;

        private void Awake()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            Dispose();
        }

        public void Initialize()
        {
            _startButton.onClick.AddListener(() => ViewModel.OnStartGame());
            _settingsButton.onClick.AddListener(() => ViewModel.OnSettingsOpen());
            Debug.Log("MenuView initialized");
        }

        public void Dispose()
        {
            _startButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
        }
    }
}