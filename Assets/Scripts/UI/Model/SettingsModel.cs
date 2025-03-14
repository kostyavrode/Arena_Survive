using UnityEngine;

namespace UI.Model
{
    public class SettingsModel
    {
        private float _musicVolume;
        private float _sfxVolume;

        public float MusicVolume
        {
            get => _musicVolume;
            set
            {
                _musicVolume = Mathf.Clamp01(value);
                AudioListener.volume = _musicVolume;
                SaveSettings();
            }
        }

        public float SFXVolume
        {
            get => _sfxVolume;
            set
            {
                _sfxVolume = Mathf.Clamp01(value);
                
                SaveSettings();
            }
        }

        public SettingsModel()
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            _musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            _sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

            AudioListener.volume = _musicVolume;
        }

        private void SaveSettings()
        {
            PlayerPrefs.SetFloat("MusicVolume", _musicVolume);
            PlayerPrefs.SetFloat("SFXVolume", _sfxVolume);
            PlayerPrefs.Save();
        }
    }
}