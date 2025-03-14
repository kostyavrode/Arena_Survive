using System;
using UnityEngine;
using Zenject;

namespace UI.View
{
    public abstract class ViewBase : MonoBehaviour, IInitializable, IDisposable
    {
        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
        
        public virtual void Initialize() { Debug.Log($"🟢 {GetType().Name} Initialize() вызван");}
        public virtual void Dispose() {}
    }
}