namespace FPS.AI.Behaviour
{
    public class BehaviourTree
    {
        private INode rootNode;
        private BehaviourTreeState treeState;

        public BehaviourTree(INode rootNode)
        {
            this.rootNode = rootNode;
            treeState = new BehaviourTreeState();
        }

        public void Tick()
        {
            rootNode.Evaluate(treeState);
        }
    }
}