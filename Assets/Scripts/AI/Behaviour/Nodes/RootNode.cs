using FPS.AI.Behaviour.Data;
using UnityEngine;

namespace FPS.AI.Behaviour.Nodes
{
    public class RootNode : BehaviourNode<RootNodeData>
    {
        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            if (Children.Count == 0)
            {
                return NodeState.Failure;
            }

            if (Children.Count > 1)
            {
                Debug.LogError("[AI] Root not can only have one child.");
                return NodeState.Failure;
            }

            return Children[0].Evaluate(treeState);
        }
    }
}