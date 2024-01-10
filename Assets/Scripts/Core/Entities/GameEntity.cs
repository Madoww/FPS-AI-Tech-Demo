using FPS.Common;
using System;
using UnityEngine;

namespace FPS.Entities
{
    public abstract class GameEntity : MonoBehaviour, IInitializable, IDeinitializable
    {
        public event Action OnInitialized;
        public event Action OnDeinitialized;

        [SerializeField]
        private bool selfInitialize;

        public bool IsInitialized { get; private set; }
        public string Guid { get; private set; }

        private void Awake()
        {
            if (selfInitialize)
            {
                Initialize();
            }
        }

        private void Reset()
        {
            Guid = System.Guid.NewGuid().ToString();
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

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDeinitialize()
        { }
    }
}