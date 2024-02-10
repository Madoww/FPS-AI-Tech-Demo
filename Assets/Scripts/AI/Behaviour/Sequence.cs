using FPS.AI.Behaviour.Data;

namespace FPS.AI.Behaviour
{
    public class Sequence : BehaviourNode<SequenceData>
    {
        //public Sequence(IList<IBehaviourNode> nodes, OverrideCondition overrideCondition = OverrideCondition.None)
        //{
        //    this.nodes = nodes;
        //    OverrideCondition = overrideCondition;
        //}

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            if (treeState.TryGetRunningChild(this, out IBehaviourNode runningChild))
            {
                var runningChildIndex = Children.IndexOf(runningChild);
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
                var higherPriorityNode = Children[i];
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