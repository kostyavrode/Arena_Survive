using UI.Model;
using UI.View;

namespace UI.ViewModel
{
    public class SettingsViewModel
    {
        private readonly SettingsModel _model;
        private readonly UIManager _uiManager;

        public SettingsViewModel(SettingsModel model, UIManager uiManager)
        {
            _model = model;
            _uiManager = uiManager;
        }

        public void OnSettingsClose()
        {
            _uiManager.OpenWindow<MenuView>();
        }

        public void OnMusicSliderChanged(float value)
        {
            _model.MusicVolume = value;
        }

        public void OnSFXSliderChanged(float value)
        {
            _model.SFXVolume = value;
        }
    }
}