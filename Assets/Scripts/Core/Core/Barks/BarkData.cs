using System;
using UnityEngine.Localization;

namespace FPS.Core.Barks
{
    [Serializable]
    public class BarkData
    {
        public LocalizedString localizedStringReference;
        public string audioName;

        public string LocalizedText => localizedStringReference?.GetLocalizedString() ?? string.Empty;
    }
}