using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.UI
{
    public class UiHandler : IUiHandler
    {
        public event Action OnInitialized;
        public event Action OnDeinitialized;

        public bool IsInitialized { get; private set; }

        public void Initialize()
        {
            if(IsInitialized)
            {
                return;
            }

            OnInitialize();
            IsInitialized = true;
            OnInitialized?.Invoke();
        }

        public void Deinitialize()
        {
            if(!IsInitialized)
            {
                return;
            }

            OnDeinitialize();
            IsInitialized = false;
            OnDeinitialized?.Invoke();
        }

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDeinitialize()
        { }
    }
}