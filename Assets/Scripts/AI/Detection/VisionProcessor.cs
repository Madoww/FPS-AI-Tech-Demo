using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Detection
{
    public class VisionProcessor : ISenseProcessor
    {
        [SerializeField]
        private VisionSense visionSense;

        public ISense Sense => visionSense;

        public IList<SensedTargetData> Process()
        {
            return new List<SensedTargetData>();
        }
    }
}