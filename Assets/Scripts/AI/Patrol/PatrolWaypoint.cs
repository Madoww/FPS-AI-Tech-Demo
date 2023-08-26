using System;
using UnityEngine;

namespace FPS.AI.Patrol
{
    [Serializable]
    public class PatrolWaypoint
    {
        [SerializeField]
        private Transform waypoint;

        public Vector3 Position => waypoint.position;
    }
}