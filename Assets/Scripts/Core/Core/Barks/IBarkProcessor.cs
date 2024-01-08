using FPS.Common;
using System;

namespace FPS.Core.Barks
{
    public interface IBarkProcessor : IInitializable, IDeinitializable
    {
        event Action<BarkData> OnTrigerred;

        void Process();
    }
}