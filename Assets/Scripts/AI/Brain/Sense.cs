using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Brain
{
    public abstract class Sense : MonoBehaviour
    {
        public abstract IList<SenseData> Evaluate();
    }
}