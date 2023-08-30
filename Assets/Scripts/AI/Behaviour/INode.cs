namespace FPS.AI.Behaviour
{
    public interface INode
    {
        NodeState Evaluate(BehaviourTreeState treeState);
    }
}