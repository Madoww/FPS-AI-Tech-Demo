using System.Collections.Generic;

namespace FPS.AI.Behaviour
{
    public class Sequence : Node
    {
        private IList<Node> nodes;

        public Sequence(IList<Node> nodes)
        {
            this.nodes = nodes;
        }

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            if (TryEvaluateRunningNode(treeState, out Node runningChild, out NodeState runningChildState))
            {
                if (runningChildState != NodeState.Success)
                {
                    return runningChildState;
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

        private bool TryEvaluateRunningNode(BehaviourTreeState treeState, out Node runningChild, out NodeState runningChildState)
        {
            if (treeState.TryGetRunningChild(this, out runningChild))
            {
                runningChildState = runningChild.Evaluate(treeState);
                if (runningChildState != NodeState.Running)
                {
                    treeState.UnregisterRunningChild(this);
                }

                return true;
            }

            runningChildState = default;
            return false;
        }
    }
}