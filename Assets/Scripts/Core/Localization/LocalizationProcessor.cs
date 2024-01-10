using System;
using UnityEngine.Localization;

namespace FPS.Localization
{
    public abstract class LocalizationProcessor : ILocalizationProcessor
    {
        public event Action OnInitialized;
        public event Action OnDeinitialized;

        public bool IsInitialized { get; private set; }

        protected Locale CurrentLocale { get; private set; }

        public void Initialize(Locale locale)
        {
            if (IsInitialized)
            {
                return;
            }

            CurrentLocale = locale;
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

        public abstract void SetLocale(Locale locale);

        protected virtual void OnInitialize()
        { }

        protected virtual void OnDeinitialize()
        { }
    }
}