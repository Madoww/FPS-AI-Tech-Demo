using UnityEngine;
using UnityEngine.AI;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;

    public class ActionChase : INode
    {
        private readonly NavMeshAgent navMeshAgent;

        public ActionChase(NavMeshAgent navMeshAgent)
        {
            this.navMeshAgent = navMeshAgent;
        }

        private bool returnFailre = false;

        public NodeState Evaluate(BehaviourTreeState treeState)
        {
            treeState.TryGetData<Vector3>(Blackboard.POSITION_OF_INTEREST, out var targetPosition);
            navMeshAgent.SetDestination(targetPosition);
            Debug.Log("Action: Chase");
            if (Input.GetKey(KeyCode.G))
            {
                returnFailre = true;
            }

            if (returnFailre)
            {
                return NodeState.Failure;
            }
            return NodeState.Running;
        }
    }
}