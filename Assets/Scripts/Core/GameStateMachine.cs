using Core.StateMachine;
using UnityEngine.PlayerLoop;
using Zenject.Internal;

namespace Core
{
    using System;
    using System.Collections.Generic;
    using Zenject;
    using UnityEngine;

    public class GameStateMachine : IGameStateMachine, IInitializable

    {
        private readonly Dictionary<Type, IState> _states;
        private IState _currentState;

        [Inject]
        public GameStateMachine(MenuState menu, PlayingState playing, PauseState pause)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(MenuState)] = menu,
                [typeof(PlayingState)] = playing,
                [typeof(PauseState)] = pause
            };
        }

        public void Initialize()
        {
            ChangeState<MenuState>();
        }

        private void ChangeState(Type stateType)
        {
            _currentState?.Exit();
            _currentState = (IState)_states[stateType];
            _currentState.Enter();
        }

        public void ChangeState<T>() where T : IState
        {
            ChangeState(typeof(T));
        }
    }
}