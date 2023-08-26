using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace FPS.AI.Common
{
    using FPS.AI.Behaviour;
    using FPS.AI.Patrol;

    public class ActionPatrol : INode
    {
        private readonly Transform targetTransform;
        private readonly NavMeshAgent navMeshAgent;
        private List<PatrolAreaContext> patrolAreas;

        private int currentWaypointIndex;
        private int currentPatrolAreaIndex = 0;

        public ActionPatrol(List<PatrolAreaContext> patrolAreas, Transform targetTransform, NavMeshAgent navMeshAgent)
        {
            this.targetTransform = targetTransform;
            this.navMeshAgent = navMeshAgent;
            this.patrolAreas = patrolAreas;
        }

        public NodeState Evaluate(Dictionary<string, object> data)
        {
            data.TryGetValue(Blackboard.WAS_ENEMY_SPOTTED, out var wasEnemySpottedObject);
            data.TryGetValue(Blackboard.WAS_PATROLLING, out var wasPatrollingObject);

            var wasEnemySpotted = wasEnemySpottedObject != null && (bool)wasEnemySpottedObject == true;
            var wasPatrolling = wasPatrollingObject != null && (bool)wasPatrollingObject == true;

            if (wasEnemySpotted || !wasPatrolling)
            {
                if (wasPatrollingObject == null)
                {
                    data.Add(Blackboard.WAS_PATROLLING, true);
                }
                else
                {
                    data[Blackboard.WAS_PATROLLING] = true;
                }
                currentWaypointIndex = GetClosestPatrolWaypoint();
                SetCurrentWaypoint(currentWaypointIndex);
            }

            var currentPatrolArea = patrolAreas[currentPatrolAreaIndex].patrolArea;
            var currentPatrolWaypoint = currentPatrolArea.Waypoints[currentWaypointIndex];
            var distanceToCurrentWaypoint = Vector3.Distance(targetTransform.position, currentPatrolWaypoint.Position);
            if (distanceToCurrentWaypoint < 1f)
            {
                currentWaypointIndex = currentPatrolArea.GetNextWaypointIndex(currentWaypointIndex);
                SetCurrentWaypoint(currentWaypointIndex);
            }

            return NodeState.Success;
        }

        public int GetClosestPatrolWaypoint()
        {
            var waypoints = patrolAreas[0].patrolArea.Waypoints;
            var closestWaypointIndex = 0;
            var closestWaypointDistance = float.MaxValue;
            for (int i = 0; i < waypoints.Count; i++)
            {
                var distance = Vector3.Distance(targetTransform.position, waypoints[i].Position);
                if (distance < closestWaypointDistance)
                {
                    closestWaypointDistance = distance;
                    closestWaypointIndex = i;
                }
            }

            return closestWaypointIndex;
        }

        private void SetCurrentWaypoint(int index)
        {
            Debug.Log("Setting current waypoint: " + index);
            var currentPatrolArea = patrolAreas[currentPatrolAreaIndex].patrolArea;
            var newPatrolWaypoint = currentPatrolArea.Waypoints[index];
            navMeshAgent.SetDestination(newPatrolWaypoint.Position);
        }

        [Inject]
        internal void Bind(IPatrolDataProvider patrolDataProvider)
        {
            patrolAreas = patrolDataProvider.GetPatrolData();
        }
    }
}