namespace FPS.AI.Behaviour
{
    public abstract class Node
    {
        public virtual OverrideCondition OverrideCondition => OverrideCondition.None;

        public abstract NodeState Evaluate(BehaviourTreeState treeState);
    }
}