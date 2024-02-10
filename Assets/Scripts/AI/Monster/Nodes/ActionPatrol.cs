using FPS.AI.Behaviour;
using FPS.AI.Behaviour.Nodes;

namespace FPS.AI.Monster.Nodes
{
    public class ActionPatrol : ActionGenericPatrol
    {
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