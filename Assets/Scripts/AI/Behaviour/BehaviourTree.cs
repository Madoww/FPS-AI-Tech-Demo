namespace FPS.AI.Behaviour
{
    public class BehaviourTree
    {
        private Node rootNode;
        private BehaviourTreeState treeState;

        public BehaviourTree(Node rootNode)
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