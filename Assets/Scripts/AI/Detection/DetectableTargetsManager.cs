using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Detection
{
    public class DetectableTargetsManager : MonoBehaviour, IDetectableTargetsManager
    {
        public IList<DetectableTarget> DetectableTargets => detectableTargets;

        private List<DetectableTarget> detectableTargets = new List<DetectableTarget>();

        private void Awake()
        {
            var sceneDetectableObjects = FindObjectsOfType<DetectableTarget>(true);
            detectableTargets = new List<DetectableTarget>(sceneDetectableObjects);
        }

        public void Register(DetectableTarget target)
        {
            detectableTargets.Add(target);
        }

        public void Unregister(DetectableTarget target)
        {
            detectableTargets.Remove(target);
        }
    }
}