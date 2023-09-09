using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace FPS.AI.Common
{
    using FPS.AI.Behaviour;
    using FPS.AI.Patrol;

    public class ActionGenericPatrol : Node
    {
        protected readonly Transform targetTransform;
        protected readonly NavMeshAgent navMeshAgent;
        protected List<PatrolArea> patrolAreas;

        protected int currentWaypointIndex;
        protected int currentPatrolAreaIndex = 0;
        protected float minDistanceToWaypoint = 1f;

        public ActionGenericPatrol(List<PatrolArea> patrolAreas, Transform targetTransform, NavMeshAgent navMeshAgent)
        {
            this.targetTransform = targetTransform;
            this.navMeshAgent = navMeshAgent;
            this.patrolAreas = patrolAreas;
        }

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            var currentPatrolArea = patrolAreas[currentPatrolAreaIndex];
            var currentPatrolWaypoint = currentPatrolArea.Waypoints[currentWaypointIndex];
            var distanceToCurrentWaypoint = Vector3.Distance(targetTransform.position, currentPatrolWaypoint.Position);
            if (distanceToCurrentWaypoint < minDistanceToWaypoint)
            {
                currentWaypointIndex = currentPatrolArea.GetNextWaypointIndex(currentWaypointIndex);
                SetCurrentWaypoint(currentWaypointIndex);
            }

            return NodeState.Running;
        }

        public int GetClosestPatrolWaypoint()
        {
            var closestWaypointIndex = 0;
            var closestWaypointDistance = float.MaxValue;
            foreach (PatrolArea patrolArea in patrolAreas)
            {
                var waypoints = patrolArea.Waypoints;
                for (int i = 0; i < waypoints.Count; i++)
                {
                    var distance = Vector3.Distance(targetTransform.position, waypoints[i].Position);
                    if (distance < closestWaypointDistance)
                    {
                        closestWaypointDistance = distance;
                        closestWaypointIndex = i;
                    }
                }
            }

            return closestWaypointIndex;
        }

        protected void SetCurrentWaypoint(int index)
        {
            var currentPatrolArea = patrolAreas[currentPatrolAreaIndex];
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