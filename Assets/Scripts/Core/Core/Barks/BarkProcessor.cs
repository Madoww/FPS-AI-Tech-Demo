using System;
using UnityEngine;

namespace FPS.Core.Barks
{
    public class BarkProcessor : IBarkProcessor
    {
        public event Action OnInitialized;
        public event Action OnDeinitialized;
        public event Action<BarkData> OnTrigerred;

        [SerializeField]
        private BarkData data;

        public bool IsInitialized { get; private set; }

        public void Initialize()
        {
            if (IsInitialized)
            {
                return;
            }

            OnInitialize();
            IsInitialized = true;
            OnInitialized?.Invoke();
        }
        public void Deinitialize()
        {
            if (!IsInitialized)
            {
                return;
            }

            OnDeinitialize();
            IsInitialized = false;
            OnDeinitialized?.Invoke();
        }

        public virtual void Process()
        { }

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDeinitialize()
        { }

        protected virtual void Trigger()
        {
            OnTrigerred?.Invoke(data);
        }
    }
}