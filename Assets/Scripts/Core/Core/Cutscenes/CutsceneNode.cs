using System;
using System.Collections.Generic;

namespace FPS.Core.Cutscenes
{
    public abstract class CutsceneNode<T> : ICutsceneNode where T : CutsceneNodeData
    {
        private readonly List<ICutsceneNode> children = new List<ICutsceneNode>();

        private T data;

        public T Data => data;
        public Type DataType => typeof(T);
        public IReadOnlyList<ICutsceneNode> Children => children;

        public void Setup(CutsceneNodeData data)
        {
            this.data = data as T;
        }

        public void AddChild(ICutsceneNode child)
        {
            children.Add(child);
        }

        public void AddChildren(IList<ICutsceneNode> children)
        {
            foreach (ICutsceneNode child in children)
            {
                AddChild(child);
            }
        }

        public abstract void Execute();
        public virtual void ExecuteChildren()
        {
            foreach (ICutsceneNode child in Children)
            {
                child.Execute();
            }
        }
    }
}