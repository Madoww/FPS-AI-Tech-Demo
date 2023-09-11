using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Brain
{
    using FPS.AI.Detection;

    public class AiBrain : MonoBehaviour
    {
        [SerializeReference, ReferencePicker]
        private List<ISenseProcessor> senseProcessors;
        //TODO:
        // Awareness
    }
}