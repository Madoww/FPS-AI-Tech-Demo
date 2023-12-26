using System;
using System.Collections.Generic;

namespace FPS.Core.Cutscenes
{
    public abstract class CutsceneNode<T> : ICutsceneNode where T : CutsceneNodeData
    {
        private T data;
        private List<ICutsceneNode> children;

        public T Data => data;
        public Type DataType => typeof(T);
        public IReadOnlyList<ICutsceneNode> Children => children;

        public abstract void Execute();

        public void Setup(CutsceneNodeData data)
        {
            this.data = data as T;
        }
    }
}