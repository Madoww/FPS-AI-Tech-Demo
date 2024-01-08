using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Barks
{
    public class BarksHandler : MonoBehaviour
    {
        [SerializeReference, ReferencePicker, ReorderableList]
        private List<IBarkProcessor> processors;
    }
}