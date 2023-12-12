using System.Collections.Generic;

namespace FPS.AI.Behaviour
{
    public class Sequence : Node
    {
        private IList<Node> nodes;

        public Sequence(IList<Node> nodes, OverrideCondition overrideCondition = OverrideCondition.None)
        {
            this.nodes = nodes;
            OverrideCondition = overrideCondition;
        }

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            if (treeState.TryGetRunningChild(this, out Node runningChild))
            {
                var runningChildIndex = nodes.IndexOf(runningChild);
                var higherPriorityNodeState = EvaluateHigherPriorityNodes(treeState, runningChildIndex);
                if (higherPriorityNodeState == NodeState.Failure
                    || higherPriorityNodeState == NodeState.Running)
                {
                    return higherPriorityNodeState;
                }

                NodeState runningChildState = runningChild.Evaluate(treeState);
                if (runningChildState != NodeState.Running)
                {
                    treeState.UnregisterRunningChild(this);
                }
            }

            bool isAnyNodeRunning = false;
            for (int i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                if (runningChild != null)
                {
                    var runningChildIndex = nodes.IndexOf(runningChild);
                    i = runningChildIndex;
                    runningChild = null;
                    continue;
                }

                switch (node.Evaluate(treeState))
                {
                    case NodeState.Success:
                        break;
                    case NodeState.Failure:
                        return NodeState.Failure;
                    case NodeState.Running:
                        treeState.RegisterRunningChild(this, node);
                        isAnyNodeRunning = true;
                        break;
                }
            }

            return isAnyNodeRunning ? NodeState.Running : NodeState.Success;
        }

        private NodeState EvaluateHigherPriorityNodes(BehaviourTreeState treeState, int runningChildIndex)
        {
            for (int i = 0; i < runningChildIndex; i++)
            {
                var higherPriorityNode = nodes[i];
                if (higherPriorityNode.OverrideCondition != OverrideCondition.LowerPriority)
                {
                    continue;
                }

                var higherPriorityNodeResult = higherPriorityNode.Evaluate(treeState);
                if (higherPriorityNodeResult == NodeState.Success)
                {
                    continue;
                }

                treeState.UnregisterRunningChild(this);
                if (higherPriorityNodeResult == NodeState.Failure)
                {
                    return NodeState.Failure;
                }

                treeState.RegisterRunningChild(this, higherPriorityNode);
                return NodeState.Running;
            }

            return NodeState.Success;
        }
    }
}