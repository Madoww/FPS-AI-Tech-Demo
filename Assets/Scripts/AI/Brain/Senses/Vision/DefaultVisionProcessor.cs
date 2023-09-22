using System.Collections.Generic;

namespace FPS.AI.Brain.Senses.Vision
{
    public class DefaultVisionProcessor : IVisionProcessor
    {
        public IList<ProcessedSenseData> Process(List<VisionSenseData> visionData)
        {
            var processedData = new List<ProcessedSenseData>();
            foreach (var data in visionData)
            {
                processedData.Add(new ProcessedSenseData()
                {
                    position = data.position
                });
            }

            return processedData;
        }
    }
}