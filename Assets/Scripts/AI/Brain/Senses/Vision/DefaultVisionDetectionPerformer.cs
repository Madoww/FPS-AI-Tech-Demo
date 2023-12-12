using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FPS.AI.Brain.Senses.Vision
{
    using FPS.AI.Detection;

    public class DefaultVisionDetectionPerformer : VisionDetectionBehaviour
    {
        [SerializeField]
        private float visionRange;
        [SerializeField, Range(0, 180f), Tooltip("In degrees.")]
        private float visionAngle;
        [SerializeField]
        private LayerMask detectionMask;

        private IDetectableTargetsManager detectableTargetsManager;
        private float cosVisionAngle = -1;

        private float CosVisionAngle
        {
            get
            {
                if (cosVisionAngle == -1)
                {
                    cosVisionAngle = Mathf.Cos(visionAngle * Mathf.Rad2Deg);
                }

                return cosVisionAngle;
            }
        }

        public override IList<DetectableTarget> Detect()
        {
            var detectedTargets = new List<DetectableTarget>();
            var detectableTargets = detectableTargetsManager.DetectableTargets;
            foreach (var target in detectableTargets)
            {
                var selfPosition = transform.position;
                var targetPosition = target.Position;
                var vectorToTarget = targetPosition - selfPosition;
                var squaredVisionRange = Mathf.Pow(visionRange, 2);
                if (vectorToTarget.sqrMagnitude > squaredVisionRange)
                {
                    continue;
                }

                vectorToTarget.Normalize();
                var forwardVector = transform.forward;
                var dotProduct = Vector3.Dot(vectorToTarget, forwardVector);
                if (dotProduct < CosVisionAngle)
                {
                    continue;
                }

                RaycastHit hitResult;
                Debug.DrawRay(selfPosition, vectorToTarget * 100, Color.green);
                if (!Physics.Raycast(selfPosition, vectorToTarget, out hitResult, visionRange, detectionMask, QueryTriggerInteraction.Collide))
                {
                    continue;
                }

                var detectedTarget = hitResult.collider.GetComponent<DetectableTarget>();
                if (detectedTarget == null || !detectedTarget.Equals(target))
                {
                    continue;
                }

                detectedTargets.Add(detectedTarget);
            }

            return detectedTargets;
        }

        [Inject]
        internal void Bind(IDetectableTargetsManager detectableTargetsManager)
        {
            this.detectableTargetsManager = detectableTargetsManager;
        }
    }
}