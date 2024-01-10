using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace FPS.Localization
{
    public class LocalizationController : MonoBehaviour, ILocalizationController
    {
        [SerializeField]
        private bool selfInitialize;
        [SerializeReference, ReferencePicker, ReorderableList]
        private List<ILocalizationProcessor> localizationProcessors;

        public IReadOnlyList<ILocalizationProcessor> Processors => localizationProcessors;

        private void Awake()
        {
            if (selfInitialize)
            {
                Initialize();
            }
        }

        private void OnDestroy()
        {
            Deinitialize();
        }

        private void Initialize()
        {
            LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
            var activeLocale = LocalizationSettings.SelectedLocale;
            foreach (ILocalizationProcessor processor in localizationProcessors)
            {
                if (processor == null)
                {
                    Debug.LogWarning("Null localization processor found.");
                    continue;
                }

                processor.Initialize(activeLocale);
            }
        }

        private void Deinitialize()
        {
            LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
            foreach (ILocalizationProcessor processor in localizationProcessors)
            {
                if (processor == null)
                {
                    continue;
                }

                processor.Deinitialize();
            }
        }

        private void OnLocaleChanged(Locale locale)
        {
            foreach (var processor in localizationProcessors)
            {
                processor.SetLocale(locale);
            }
        }
    }
}