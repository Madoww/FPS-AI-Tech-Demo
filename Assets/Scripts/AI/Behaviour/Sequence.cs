using System.Collections.Generic;

namespace FPS.AI.Behaviour
{
    public class Sequence : INode
    {
        private ICollection<INode> nodes;

        public Sequence(ICollection<INode> nodes)
        {
            this.nodes = nodes;
        }

        public NodeState Evaluate(BehaviourTreeState treeState)
        {
            if (treeState.TryGetRunningChild(this, out var runningChild))
            {
                NodeState runningChildState = runningChild.Evaluate(treeState);
                if (runningChildState == NodeState.Running)
                {
                    return NodeState.Running;
                }

                treeState.UnregisterRunningChild(this);

                if (runningChildState == NodeState.Failure)
                {
                    return NodeState.Failure;
                }
            }

            bool isAnyNodeRunning = false;
            foreach (INode node in nodes)
            {
                if (runningChild != null)
                {
                    if (node != runningChild)
                    {
                        continue;
                    }
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
    }
}