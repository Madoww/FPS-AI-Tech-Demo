using UnityEngine;
using UnityEngine.AI;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;

    public class ActionChase : Node
    {
        private readonly NavMeshAgent navMeshAgent;

        public ActionChase(NavMeshAgent navMeshAgent)
        {
            this.navMeshAgent = navMeshAgent;
        }

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            treeState.TryGetData<Vector3>(Blackboard.POSITION_OF_INTEREST, out var targetPosition);
            navMeshAgent.SetDestination(targetPosition);
            Debug.Log("Action: Chase");
            return NodeState.Running;
        }
    }
}