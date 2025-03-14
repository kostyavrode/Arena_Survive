using System;
using UI.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class PauseView : View<PauseViewModel>
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _menuButton;

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
            _resumeButton.onClick.AddListener(() => ViewModel.ResumeGame());
            _menuButton.onClick.AddListener(() => ViewModel.GoToMainMenu());
        }

        public void Dispose()
        {
            _resumeButton.onClick.RemoveAllListeners();
            _menuButton.onClick.RemoveAllListeners();
        }
    }
}