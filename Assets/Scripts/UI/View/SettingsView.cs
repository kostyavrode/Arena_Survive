using UI.ViewModel;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class SettingsView : View<SettingsViewModel>
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _sfxSlider;
        
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
            _closeButton.onClick.AddListener( () => ViewModel.OnSettingsClose());
            _musicSlider.onValueChanged.AddListener(value => ViewModel.OnMusicSliderChanged(value));
            _sfxSlider.onValueChanged.AddListener( value => ViewModel.OnSFXSliderChanged(value));
        }

        public void Dispose()
        {
            _closeButton.onClick.RemoveAllListeners();
            _musicSlider.onValueChanged.RemoveAllListeners();
            _sfxSlider.onValueChanged.RemoveAllListeners();
        }
    }
}