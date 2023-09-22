using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Brain
{
    public class AiBrain : MonoBehaviour
    {
        [SerializeField]
        private List<Sense> senses;

        private void Update()
        {
            var sensesData = new List<ProcessedSenseData>();

            foreach (Sense sense in senses)
            {
                var senseData = sense.Evaluate();
                sensesData.AddRange(senseData);
            }

            if (sensesData.Count > 0)
            {
                Debug.Log("Target detected");
            }
        }
    }
}