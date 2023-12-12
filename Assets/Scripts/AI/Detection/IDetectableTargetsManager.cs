using System.Collections.Generic;

namespace FPS.AI.Detection
{
    public interface IDetectableTargetsManager
    {
        IList<DetectableTarget> DetectableTargets { get; }

        void Register(DetectableTarget target);
        void Unregister(DetectableTarget target);
    }
}