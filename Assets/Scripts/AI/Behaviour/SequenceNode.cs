using System.Collections.Generic;

namespace FPS.AI.Behaviour
{
    public class SequenceNode : INode
    {
        private ICollection<INode> nodes;

        public SequenceNode(ICollection<INode> nodes)
        {
            this.nodes = nodes;
        }

        public NodeState Evaluate(BehaviourTreeState treeState)
        {
            bool isAnyNodeRunning = false;
            foreach (INode node in nodes)
            {
                switch (node.Evaluate(treeState))
                {
                    case NodeState.Success:
                        break;
                    case NodeState.Failure:
                        return NodeState.Failure;
                    case NodeState.Running:
                        isAnyNodeRunning = true;
                        break;
                }
            }

            return isAnyNodeRunning ? NodeState.Running : NodeState.Success;
        }
    }
}