using System;

namespace FPS.Common
{
    public interface IInitializable
    {
        event Action OnInitialized;

        bool IsInitialized { get; }

        void Initialize();
    }
}