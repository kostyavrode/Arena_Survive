using UI;
using UI.View;
using UnityEngine;
using Zenject;

namespace Core.StateMachine
{
    public class MenuState : IState
    {
        private UIManager _uiManager;

        [Inject]
        public void Construct(UIManager uiManager)
        {
            _uiManager = uiManager;
        }
        public void Enter()
        {
            _uiManager.OpenWindow<MenuView>();
        }

        public void Exit()
        {

        }
    }
}