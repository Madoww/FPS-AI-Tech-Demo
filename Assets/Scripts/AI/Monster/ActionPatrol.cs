using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;
    using FPS.AI.Common;
    using FPS.AI.Patrol;

    public class ActionPatrol : ActionGenericPatrol
    {
        public ActionPatrol(List<PatrolArea> patrolAreas, Transform targetTransform, NavMeshAgent navMeshAgent)
            : base(patrolAreas, targetTransform, navMeshAgent)
        { }

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            treeState.TryGetData<bool>(Blackboard.IS_PATROLLING, out var isPatrolling);
            if (isPatrolling == false)
            {
                treeState.SetData(Blackboard.IS_PATROLLING, true);
                currentWaypointIndex = GetClosestPatrolWaypoint();
                SetCurrentWaypoint(currentWaypointIndex);
            }

            return base.Evaluate(treeState);
        }
    }
}