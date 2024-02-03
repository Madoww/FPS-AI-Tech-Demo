using FPS.Common;
using System;
using UnityEngine;

namespace FPS.UI.Views
{
    public class UiViewController : MonoBehaviour, IInitializable, IDeinitializable
    {
        public event Action OnInitialized;
        public event Action OnDeinitialized;

        [SerializeField]
        private UiView view;

        public UiView TargetView => view;

        public bool IsInitialized { get; private set; }

        private void Awake()
        {
            TargetView.OnInitialized += Initialize;
            TargetView.OnDeinitialized += Deinitialize;
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

    public class UiViewController<T> : UiViewController where T : UiView
    {
        public new T TargetView => (T)base.TargetView;
    }
}