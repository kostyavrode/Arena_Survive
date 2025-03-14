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
        private readonly Dictionary<Type, ViewBase> _windows = new();
        private ViewBase _currentWindow;

        [Inject]
        public UIManager([InjectOptional] List<ViewBase> views)
        {
            if (views == null || views.Count == 0)
            {
                Debug.LogError("UIManager: Не найдено ни одного окна!");
                return;
            }

            foreach (var view in views)
            {
                _windows[view.GetType()] = view;
                view.Hide();
            }
        }

        public void OpenWindow<TView>() where TView : ViewBase
        {
            if (_currentWindow != null)
            {
                _currentWindow.Hide();
            }

            if (_windows.TryGetValue(typeof(TView), out var newWindow))
            {
                newWindow.Show();
                _currentWindow = newWindow;
            }
            else
            {
                Debug.LogError($"UIManager: окно {typeof(TView).Name} не найдено.");
            }
        }
    }
}