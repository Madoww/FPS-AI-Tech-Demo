using FPS.AI.Behaviour.Data;

namespace FPS.AI.Behaviour
{
    public class Selector : BehaviourNode<SelectorData>
    {
        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            if (treeState.TryGetRunningChild(this, out var runningChild))
            {
                var runningChildIndex = Children.IndexOf(runningChild);
                var higherPriorityNodeState = EvaluateHigherPriorityNodes(treeState, runningChildIndex);
                if (higherPriorityNodeState == NodeState.Success
                    || higherPriorityNodeState == NodeState.Running)
                {
                    return higherPriorityNodeState;
                }

                NodeState runningChildState = runningChild.Evaluate(treeState);
                if (runningChildState == NodeState.Running)
                {
                    return NodeState.Running;
                }

                treeState.UnregisterRunningChild(this);

                if (runningChildState == NodeState.Success)
                {
                    return NodeState.Success;
                }
            }

            for (int i = 0; i < Children.Count; i++)
            {
                var node = Children[i];
                if (runningChild != null)
                {
                    var runningChildIndex = Children.IndexOf(runningChild);
                    i = runningChildIndex;
                    runningChild = null;
                    continue;
                }

                switch (node.Evaluate(treeState))
                {
                    case NodeState.Failure:
                        continue;
                    case NodeState.Success:
                        return NodeState.Success;
                    case NodeState.Running:
                        treeState.RegisterRunningChild(this, node);
                        return NodeState.Running;
                }
            }

            return NodeState.Failure;
        }

        private NodeState EvaluateHigherPriorityNodes(BehaviourTreeState treeState, int runningChildIndex)
        {
            for (int i = 0; i < runningChildIndex; i++)
            {
                var higherPriorityNode = Children[i];
                if (higherPriorityNode.OverrideCondition != OverrideCondition.LowerPriority)
                {
                    continue;
                }

                var higherPriorityNodeResult = higherPriorityNode.Evaluate(treeState);
                if (higherPriorityNodeResult == NodeState.Failure)
                {
                    continue;
                }

                treeState.UnregisterRunningChild(this);
                if (higherPriorityNodeResult == NodeState.Success)
                {
                    return NodeState.Success;
                }

                treeState.RegisterRunningChild(this, higherPriorityNode);
                return NodeState.Running;
            }

            return NodeState.Failure;
        }
    }
}