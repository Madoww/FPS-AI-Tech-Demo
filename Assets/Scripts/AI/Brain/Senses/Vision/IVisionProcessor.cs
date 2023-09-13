using System.Collections.Generic;

namespace FPS.AI.Brain.Senses.Vision
{
    public interface IVisionProcessor
    {
        IList<ProcessedSenseData> Process(VisionSenseData visionData);
    }
}