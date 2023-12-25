namespace FPS.Core.Cutscenes
{
    public abstract class CutsceneNode<T> where T : CutsceneNodeData
    {
        private T data;

        public T Data => data;

        public CutsceneNode(T data)
        {
            this.data = data;
        }

        public abstract void Execute();
    }
}