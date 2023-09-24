using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Brain
{
    public class AiBrain : MonoBehaviour
    {
        [SerializeField]
        private List<Sense> senses;

        public SenseData MostCertainData { get; private set; }

        private void Update()
        {
            var senseDatas = new List<SenseData>();

            foreach (Sense sense in senses)
            {
                var senseData = sense.Evaluate();
                senseDatas.AddRange(senseData);
            }

            float mostCertainValue = float.MinValue;
            foreach (SenseData senseData in senseDatas)
            {
                if (senseData.certainty > mostCertainValue)
                {
                    MostCertainData = senseData;
                }
            }
        }
    }
}