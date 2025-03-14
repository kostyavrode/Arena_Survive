using System;
using System.Collections.Generic;
using System.Linq;
using UI.View;
using UI.ViewModel;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIManager
    {
        private readonly Dictionary<Type, IInitializable> _windows = new();
        private IInitializable _currentWindow;

        [Inject]
        public UIManager([InjectOptional] List<IInitializable> views)
        {
            foreach (var view in views)
            {
                _windows[view.GetType()] = view;
                ((ViewBase)view).Hide();
            }
        }

        public void OpenWindow<TView>() where TView : ViewBase
        {
            if (_currentWindow != null)
            {
                ((ViewBase)_currentWindow).Hide();
            }

            if (_windows.TryGetValue(typeof(TView), out var newWindow))
            {
                ((ViewBase)newWindow).Show();
                _currentWindow = newWindow;
            }
            else
            {
                Debug.LogError($"UIManager: окно {typeof(TView).Name} не найдено.");
            }
        }
    }
}