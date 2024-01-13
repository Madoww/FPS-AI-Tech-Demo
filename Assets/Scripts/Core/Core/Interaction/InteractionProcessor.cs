using System;

namespace FPS.Core.Interaction
{
    public abstract class InteractionProcessor : IInteractionProcessor
    {
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

        public virtual void Process(Interactable interactable)
        { }

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDeinitialize()
        { }
    }
}