using System;
using System.Collections.Generic;

namespace FPS.AI.Behaviour
{
    public abstract class BehaviourNode<T> : IBehaviourNode where T : BehaviourNodeData
    {
        private readonly List<IBehaviourNode> children = new List<IBehaviourNode>();

        private T data;

        public IList<IBehaviourNode> Children => children;
        public Type DataType => typeof(T);
        public T Data => data;

        public virtual OverrideCondition OverrideCondition { get; set; } = OverrideCondition.None;
        public abstract NodeState Evaluate(BehaviourTreeState treeState);

        public void Setup(BehaviourNodeData data)
        {
            this.data = data as T;
        }

        public void AddChild(IBehaviourNode child)
        {
            children.Add(child);
        }

        public void AddChildren(IList<IBehaviourNode> children)
        {
            foreach (IBehaviourNode child in children)
            {
                AddChild(child);
            }
        }
    }
}