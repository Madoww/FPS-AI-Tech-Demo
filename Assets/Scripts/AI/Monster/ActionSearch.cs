using UnityEngine;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;

    public class ActionSearch : INode
    {
        private Transform target;

        //TODO: Rework temporary testing solution.
        public ActionSearch(Transform target)
        {
            this.target = target;
        }

        public NodeState Evaluate(BehaviourTreeState treeState)
        {
            var targetPosition = target.position;
            treeState.SetData(Blackboard.POSITION_OF_INTEREST, targetPosition);
            Debug.Log("Action: Search");
            return NodeState.Success;
        }
    }
}