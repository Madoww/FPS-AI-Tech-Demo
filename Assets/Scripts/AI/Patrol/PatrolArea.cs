using System;
using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Patrol
{
    [Serializable]
    public class PatrolArea
    {
        [SerializeField]
        private List<PatrolWaypoint> waypoints;

        public IReadOnlyList<PatrolWaypoint> Waypoints => waypoints;

        public int GetNextWaypointIndex(int index)
        {
            var nextIndex = index >= waypoints.Count - 1 ? 0 : index + 1;
            return nextIndex;
        }
    }
}