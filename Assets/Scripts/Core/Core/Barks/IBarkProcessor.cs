using System;

namespace FPS.Core.Barks
{
    public interface IBarkProcessor
    {
        event Action OnTrigerred;

        void Process();
    }
}