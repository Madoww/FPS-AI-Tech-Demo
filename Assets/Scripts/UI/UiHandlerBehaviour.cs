using UnityEngine;

namespace FPS.UI
{
    public class UiHandlerBehaviour : MonoBehaviour, IUiHandler
    {
        public bool IsTickable => false;
        public bool IsInitialized { get; private set; }

        public void Initialize()
        {
            if (IsInitialized)
            {
                return;
            }

            OnInitialize();
            IsInitialized = true;
        }

        public void Deinitialize()
        {
            if (!IsInitialized)
            {
                return;
            }

            OnDeinitialize();
            IsInitialized = false;
        }

        public virtual void Tick()
        { }

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDeinitialize()
        { }
    }
}