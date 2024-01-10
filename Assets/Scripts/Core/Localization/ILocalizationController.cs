using System.Collections.Generic;

namespace FPS.Localization
{
    public interface ILocalizationController
    {
        IReadOnlyList<ILocalizationProcessor> Processors { get; }
    }
}
