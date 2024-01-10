using FMODUnity;
using System;
using UnityEngine.Localization;

namespace FPS.Localization.Processors
{
    [Serializable]
    public class FmodBankLocaleDefinition
    {
        public Locale locale;
        [BankRef]
        public string bankName;
    }
}