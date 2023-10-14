using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace FPS.AI.Brain.Senses.Vision
{
    using FPS.AI.Detection;

    public class VisionSense : Sense
    {
        [SerializeField]
        private VisionDetectionBehaviour visionProcessor;
        [SerializeField]
        private float registerAsExistingMaxRange;
        [SerializeField]
        private float certaintyDeteriorationMultiplier = 1f;

        private List<VisionSenseData> data = new List<VisionSenseData>();
        private IDetectableTargetsManager targetsManager;

        private void Awake()
        {
            Assert.IsNotNull(visionProcessor, $"{nameof(VisionDetectionBehaviour)} not provided.");
        }

        public override IList<SenseData> Evaluate()
        {
            DeteriorateExistingCertainties();
            var detectedTargets = visionProcessor.Detect();
            UpdateDetectedTargets(detectedTargets);

            var senseData = new List<SenseData>();
            foreach (var visionData in data)
            {
                senseData.Add(new SenseData()
                {
                    position = visionData.position,
                    certainty = visionData.certainty
                });
            }

            return senseData;
        }

        [Inject]
        internal void Bind(IDetectableTargetsManager targetsManager)
        {
            this.targetsManager = targetsManager;
        }

        private void UpdateDetectedTargets(IList<DetectableTarget> detectableTargets)
        {
            foreach (var target in detectableTargets)
            {
                if (TryUpdateExisting(target))
                {
                    return;
                }

                var visionData = new VisionSenseData()
                {
                    position = target.Position,
                    certainty = 1
                };
                data.Add(visionData);
            }

            Debug.Log("===============");
            foreach (var target in data)
            {
                Debug.Log(target.position + " / " + target.certainty);
            }
        }

        private bool TryUpdateExisting(DetectableTarget target)
        {
            foreach (VisionSenseData senseData in data)
            {
                var targetPosition = target.Position;
                var existingSensedTargetPosition = senseData.position;
                if (Vector3.Distance(targetPosition, existingSensedTargetPosition) < registerAsExistingMaxRange)
                {
                    senseData.position = target.Position;
                    senseData.certainty = 1f;
                    return true;
                }
            }

            return false;
        }

        private void DeteriorateExistingCertainties()
        {
            foreach (var senseData in data)
            {
                senseData.certainty -= Time.deltaTime * certaintyDeteriorationMultiplier;
            }

            for (int i = data.Count - 1; i >= 0; i--)
            {
                if (data[i].certainty <= 0)
                {
                    data.RemoveAt(i);
                }
            }
        }
    }
}