using UnityEngine;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;
    using FPS.AI.Monster.Data;

    public class ActionSearch : BehaviourNode<ActionSearchData>
    {
        private Transform target;

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            var targetPosition = target.position;
            treeState.SetData(Blackboard.POSITION_OF_INTEREST, targetPosition);
            Debug.Log("Action: Search");
            return NodeState.Success;
        }
    }
}