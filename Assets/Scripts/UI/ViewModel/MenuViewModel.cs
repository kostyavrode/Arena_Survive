using UI.Model;
using UI.View;

namespace UI.ViewModel
{
    public class MenuViewModel
    {
        private readonly MenuModel _model;
        private readonly UIManager _uiManager;

        public MenuViewModel(MenuModel model, UIManager uiManager)
        {
            _model = model;
            _uiManager = uiManager;
        }

        public void OnStartGame()
        {
            _model.StartGame();
            _uiManager.OpenWindow<PlayingView>();
        }

        public void OnSettingsOpen()
        {
            _uiManager.OpenWindow<SettingsView>();
        }
    }
}