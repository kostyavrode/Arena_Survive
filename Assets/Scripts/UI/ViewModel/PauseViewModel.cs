using UI.Model;
using UI.View;

namespace UI.ViewModel
{
    public class PauseViewModel
    {
        private readonly PauseModel _pauseModel;
        private readonly UIManager _uiManager;

        public PauseViewModel(PauseModel pauseModel, UIManager uiManager)
        {
            _pauseModel = pauseModel;
            _uiManager = uiManager;
        }

        public void ResumeGame()
        {
            _pauseModel.SetPause(false);
            _uiManager.OpenWindow<PlayingView>();
        }

        public void GoToMainMenu()
        {
            _pauseModel.SetPause(false);
            _uiManager.OpenWindow<MenuView>();
        }
    }
}