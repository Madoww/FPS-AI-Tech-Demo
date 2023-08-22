using System.Collections.Generic;
using UnityEngine.AI;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;
    using UnityEngine;

    public class ActionChase : INode
    {
        private readonly NavMeshAgent navMeshAgent;

        public ActionChase(NavMeshAgent navMeshAgent)
        {
            this.navMeshAgent = navMeshAgent;
        }

        public NodeState Evaluate(Dictionary<string, object> data)
        {
            data.TryGetValue(Blackboard.POSITION_OF_INTEREST, out var targetPositionObject);
            if (targetPositionObject == null)
            {
                Debug.LogWarning("[AI] Started chase action despite no target position.");
                return NodeState.Failure;
            }

            Vector3 targetPosition = (Vector3)targetPositionObject;
            navMeshAgent.SetDestination(targetPosition);
            return NodeState.Running;
        }
    }
}