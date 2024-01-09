using FMODUnity;
using System;
using UnityEngine.Localization;

namespace FPS.Core.Barks
{
    [Serializable]
    public class BarkData
    {
        public LocalizedString text;
        public EventReference audio;
    }
}