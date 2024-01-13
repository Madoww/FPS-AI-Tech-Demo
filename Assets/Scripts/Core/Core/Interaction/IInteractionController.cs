using System.Collections.Generic;

namespace FPS.Core.Interaction
{
    public interface IInteractionController
    {
        IReadOnlyList<IInteractionProcessor> Processors { get; }
    }
}