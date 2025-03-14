using System;
using UnityEngine;
using Zenject;

namespace UI.View
{
    public abstract class View<TViewModel> : ViewBase
    {
        protected TViewModel ViewModel { get; private set; }
        
        [Inject]
        public void Construct(TViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}