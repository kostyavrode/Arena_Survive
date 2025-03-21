﻿using UI;
using UI.Model;
using UI.View;
using Unity.VisualScripting;
using UnityEngine;

namespace Core.StateMachine
{
    public class GameOverState : IState
    {
        private readonly UIManager _uiManager;
        private readonly GameOverModel _gameOverModel;
        private readonly PlayingModel _playingModel;

        public GameOverState(UIManager uiManager, GameOverModel gameOverModel, PlayingModel playingModel)
        {
            _uiManager = uiManager;
            _gameOverModel = gameOverModel;
            _playingModel = playingModel;
        }

        public void Enter()
        {
            _gameOverModel.SetGameOverData(_playingModel.SurvivalTime, _playingModel.Score);
            _playingModel.ResetGame();
            _uiManager.OpenWindow<GameOverView>();
        }

        public void Exit()
        {
            
        }
    }
}