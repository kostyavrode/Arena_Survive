using UI.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class MenuView : View<MenuViewModel>
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        
        public override void Initialize()
        {
            _startButton.onClick.AddListener(() => ViewModel.OnStartGame());
            _settingsButton.onClick.AddListener(() => ViewModel.OnSettingsOpen());
            Debug.Log("MenuView initialized");
        }

        public override void Dispose()
        {
            _startButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
        }
    }
}