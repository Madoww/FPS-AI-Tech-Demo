using System.Collections.Generic;

namespace FPS.AI.Detection
{
    public interface ISenseProcessor
    {
        ISense Sense { get; }

        IList<SensedTargetData> Process();
    }
}