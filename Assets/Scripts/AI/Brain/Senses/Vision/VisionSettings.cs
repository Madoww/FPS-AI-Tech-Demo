using UnityEngine;

namespace FPS.AI.Brain.Senses.Vision
{
    [CreateAssetMenu(menuName = "AI/Senses/Vision/Settings")]
    public class VisionSettings : ScriptableObject
    {
        public float range;
        [Range(0, 180f), Tooltip("In degrees.")]
        public float visionAngle;
        public LayerMask detectionMask;
    }
}