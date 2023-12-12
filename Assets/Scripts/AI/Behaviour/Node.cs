namespace FPS.AI.Behaviour
{
    public abstract class Node
    {
        public virtual OverrideCondition OverrideCondition { get; protected set; } = OverrideCondition.None;

        public abstract NodeState Evaluate(BehaviourTreeState treeState);
    }
}