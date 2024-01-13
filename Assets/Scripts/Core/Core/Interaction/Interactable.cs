using FPS.Common;
using System;
using UnityEngine;

namespace FPS.Core.Interaction
{
    public abstract class Interactable : MonoBehaviour, IInitializable, IDeinitializable
    {
        public event Action OnInteracted;
        public event Action OnInitialized;
        public event Action OnDeinitialized;

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

        public void Interact()
        {
            OnInteract();
            OnInteracted?.Invoke();
        }

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDeinitialize()
        { }

        protected virtual void OnInteract()
        { }
    }
}