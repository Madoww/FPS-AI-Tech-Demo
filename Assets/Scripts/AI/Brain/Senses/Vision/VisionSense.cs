using FPS.AI.Detection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace FPS.AI.Brain.Senses.Vision
{
    public class VisionSense : Sense
    {
        [SerializeReference, ReferencePicker]
        private IVisionProcessor visionProcessor;
        [SerializeField]
        private VisionSettings settings;

        private List<VisionSenseData> data;
        private IDetectableTargetsManager targetsManager;
        private float cosVisionAngle = -1;

        private float CosVisionAngle
        {
            get
            {
                if (cosVisionAngle == -1)
                {
                    cosVisionAngle = Mathf.Cos(settings.visionAngle * Mathf.Rad2Deg);
                }

                return cosVisionAngle;
            }
        }

        private void Awake()
        {
            Assert.IsNotNull(visionProcessor, $"{nameof(IVisionProcessor)} not provided.");
            Assert.IsNotNull(settings, $"{nameof(VisionSettings)} not provided.");
        }

        public override IList<ProcessedSenseData> Evaluate()
        {
            throw new System.NotImplementedException();
        }

        [Inject]
        internal void Bind(IDetectableTargetsManager targetsManager)
        {
            this.targetsManager = targetsManager;
        }

        private List<VisionSenseData> Run()
        {
            var detectableTargets = targetsManager.DetectableTargets;
            foreach (var target in detectableTargets)
            {
                var selfPosition = transform.position;
                var targetPosition = target.Position;
                var vectorToTarget = targetPosition - selfPosition;
                var visionRange = settings.range;
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

                var detectionMask = settings.detectionMask;
                RaycastHit hitResult;
                if (!Physics.Raycast(selfPosition, vectorToTarget, out hitResult, visionRange, detectionMask))
                {
                    continue;
                }

                var detectedTarget = hitResult.collider.GetComponent<DetectableTarget>();
                if (detectedTarget == null || !detectedTarget.Equals(target))
                {
                    continue;
                }

                SaveSeenTarget(target);
            }

            return new List<VisionSenseData>();
        }

        private void SaveSeenTarget(DetectableTarget target)
        {
            //TODO
        }
    }
}