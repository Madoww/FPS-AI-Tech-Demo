using System.Collections.Generic;

namespace FPS.AI.Brain.Senses.Vision
{
    public class DefaultVisionProcessor : IVisionProcessor
    {
        public IList<ProcessedSenseData> Process(VisionSenseData visionData)
        {
            return new List<ProcessedSenseData>();
        }
    }
}