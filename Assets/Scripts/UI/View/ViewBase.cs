using System;
using UnityEngine;
using Zenject;

namespace UI.View
{
    public abstract class ViewBase : MonoBehaviour
    {
        public virtual void Show() => gameObject.SetActive(true);
        public virtual void Hide() => gameObject.SetActive(false);
    }
}