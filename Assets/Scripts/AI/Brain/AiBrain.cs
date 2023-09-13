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
            foreach (Sense sense in senses)
            {
                sense.Evaluate();
            }
        }
    }
}