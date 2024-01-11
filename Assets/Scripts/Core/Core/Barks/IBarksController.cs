using System;

namespace FPS.Core.Barks
{
    public interface IBarksController
    {
        event Action<BarkData> OnBarkTriggered;
    }
}