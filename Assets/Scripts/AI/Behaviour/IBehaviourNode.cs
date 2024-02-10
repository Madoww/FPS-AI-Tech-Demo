using System;
using System.Collections.Generic;

namespace FPS.AI.Behaviour
{
    public interface IBehaviourNode
    {
        OverrideCondition OverrideCondition { get; set; }
        Type DataType { get; }

        NodeState Evaluate(BehaviourTreeState treeState);
        void Setup(BehaviourNodeData data);
        void AddChild(IBehaviourNode child);
        void AddChildren(IList<IBehaviourNode> children);
    }
}