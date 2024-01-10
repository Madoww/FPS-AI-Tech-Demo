using FPS.Common;
using UnityEngine.Localization;

namespace FPS.Localization
{
    public interface ILocalizationProcessor : IInitializable<Locale>, IDeinitializable
    {
        void SetLocale(Locale locale);
    }
}