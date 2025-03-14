using UI.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class PauseView : View<PauseViewModel>
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _menuButton;
        public override void Initialize()
        {
            _resumeButton.onClick.AddListener(() => ViewModel.ResumeGame());
            _menuButton.onClick.AddListener(() => ViewModel.GoToMainMenu());
        }

        public override void Dispose()
        {
            _resumeButton.onClick.RemoveAllListeners();
            _menuButton.onClick.RemoveAllListeners();
        }
    }
}