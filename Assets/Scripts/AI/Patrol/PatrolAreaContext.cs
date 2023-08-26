using System;
using UnityEngine;

namespace FPS.AI.Patrol
{
    [Serializable]
    public class PatrolAreaContext
    {
        public PatrolArea patrolArea;
        public Transform connectingWaypoint;
    }
}