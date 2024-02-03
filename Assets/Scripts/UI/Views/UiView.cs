using FPS.Common;
using System;

namespace FPS.UI.Views
{
    public class UiView : UiObject, IInitializable, IDeinitializable
    {
        public event Action OnInitialized;
        public event Action OnDeinitialized;
        public event Action<UiView> OnShowView;
        public event Action<UiView> OnHideView;

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

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDeinitialize()
        { }
    }
}