using System;
using UnityEngine;

namespace UI.Model
{
    public class PlayingModel
    {
        public event Action<int> OnScoreChanged;
        public event Action<float> OnTimeUpdated;

        private int _score;
        private float _timeRemaining;

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnScoreChanged?.Invoke(_score);
            }
        }

        public float TimeRemaining
        {
            get => _timeRemaining;
            set
            {
                _timeRemaining = Mathf.Max(0, value);
                OnTimeUpdated?.Invoke(_timeRemaining);
            }
        }

        public PlayingModel()
        {
            _score = 0;
            _timeRemaining = 60f; // Например, 60 секунд
        }

        public void UpdateTimer(float deltaTime)
        {
            if (_timeRemaining > 0)
            {
                TimeRemaining -= deltaTime;
            }
        }

        public void AddScore(int amount)
        {
            Score += amount;
        }
    }
}