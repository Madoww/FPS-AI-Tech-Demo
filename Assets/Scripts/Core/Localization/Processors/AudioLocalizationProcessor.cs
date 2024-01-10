using FMODUnity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace FPS.Localization.Processors
{
    public class AudioLocalizationProcessor : LocalizationProcessor
    {
        [SerializeField, ReorderableList]
        private List<FmodBankLocaleDefinition> localeDefinitions;

        private readonly Dictionary<Locale, string> bankByLocales = new Dictionary<Locale, string>();

        private string currentBankName;

        public override void SetLocale(Locale locale)
        {
            if (!bankByLocales.TryGetValue(locale, out string bankName))
            {
                Debug.LogError($"Failed to find FMOD Bank for {locale.name}");
                return;
            }

            if (!string.IsNullOrEmpty(currentBankName))
            {
                RuntimeManager.UnloadBank(currentBankName);
            }

            currentBankName = bankName;
            RuntimeManager.LoadBank(currentBankName);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            foreach (FmodBankLocaleDefinition localeDefinition in localeDefinitions)
            {
                var locale = localeDefinition.locale;
                var bankName = localeDefinition.bankName;
                bankByLocales.Add(locale, bankName);
            }

            SetLocale(CurrentLocale);
        }

        protected override void OnDeinitialize()
        {
            bankByLocales.Clear();
            base.OnDeinitialize();
        }
    }
}