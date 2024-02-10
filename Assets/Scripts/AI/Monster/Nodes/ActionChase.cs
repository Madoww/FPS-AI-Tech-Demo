using FPS.AI.Behaviour;
using FPS.AI.Monster.Data;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.AI.Monster.Nodes
{
    public class ActionChase : BehaviourNode<ActionChaseData>
    {
        private readonly NavMeshAgent navMeshAgent;

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            treeState.SetData(Blackboard.IS_PATROLLING, false);
            treeState.TryGetData<Vector3>(Blackboard.POSITION_OF_INTEREST, out var targetPosition);
            navMeshAgent.SetDestination(targetPosition);
            return NodeState.Running;
        }
    }
}