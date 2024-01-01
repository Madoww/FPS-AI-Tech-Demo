using System;
using System.Collections.Generic;

namespace FPS.Core.Cutscenes
{
    public abstract class CutsceneNode<T> : ICutsceneNode where T : CutsceneNodeData
    {
        public event Action OnCompleted;

        private readonly List<ICutsceneNode> children = new List<ICutsceneNode>();

        private T data;

        public T Data => data;
        public Type DataType => typeof(T);
        public IReadOnlyList<ICutsceneNode> Children => children;
        public bool IsFinished { get; private set; }

        public void Setup(CutsceneNodeData data)
        {
            this.data = data as T;
        }

        public virtual void Setup(IDataProvidersHandler providersHandler)
        { }

        public virtual void Complete()
        {
            OnCompleted?.Invoke();
            ExecuteChildren();
        }

        public abstract void Execute();

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


        public virtual void ExecuteChildren()
        {
            foreach (ICutsceneNode child in Children)
            {
                child.Execute();
            }
        }
    }
}