namespace FPS.AI.Behaviour
{
    public class BehaviourTree
    {
        private IBehaviourNode rootNode;
        private BehaviourTreeState treeState;

        public BehaviourTree(IBehaviourNode rootNode)
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