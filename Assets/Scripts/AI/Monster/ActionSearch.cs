using UnityEngine;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;

    public class ActionSearch : Node
    {
        private Transform target;

        //TODO: Rework temporary testing solution.
        public ActionSearch(Transform target)
        {
            this.target = target;
        }

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            var targetPosition = target.position;
            treeState.SetData(Blackboard.POSITION_OF_INTEREST, targetPosition);
            Debug.Log("Action: Search");
            return NodeState.Success;
        }
    }
}