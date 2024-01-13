using System;
using UnityEngine;

namespace FPS.Common
{
    public class StandaloneManager : MonoBehaviour, IInitializable, IDeinitializable
    {
        public event Action OnDeinitialized;
        public event Action OnInitialized;

        [SerializeField]
        private bool selfInitialzie;

        public bool IsInitialized { get; private set; }

        private void Awake()
        {
            if (selfInitialzie)
            {
                Initialize();
            }
        }

        private void OnDestroy()
        {
            Deinitialize();
        }

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

        public virtual void OnInitialize()
        { }

        public virtual void OnDeinitialize()
        { }
    }
}