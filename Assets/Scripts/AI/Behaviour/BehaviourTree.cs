using System.Collections.Generic;

namespace FPS.AI.Behaviour
{
    public class BehaviourTree
    {
        private INode rootNode;
        private Dictionary<string, object> data;

        public BehaviourTree(INode rootNode)
        {
            this.rootNode = rootNode;
            data = new Dictionary<string, object>();
        }

        public void Tick()
        {
            rootNode.Evaluate(data);
        }
    }
}