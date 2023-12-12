using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Brain.Senses.Vision
{
    using FPS.AI.Detection;

    public abstract class VisionDetectionBehaviour : MonoBehaviour
    {
        public abstract IList<DetectableTarget> Detect();
    }
}