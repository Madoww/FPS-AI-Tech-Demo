namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;
    using FPS.AI.Brain;

    public class ConditionIsPlayerSpotted : Node
    {
        private AiBrain aiBrain;

        public override OverrideCondition OverrideCondition => OverrideCondition.LowerPriority;

        public ConditionIsPlayerSpotted(AiBrain aiBrain)
        {
            this.aiBrain = aiBrain;
        }

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            if (aiBrain.MostCertainData?.certainty > 0.2)
            {
                return NodeState.Success;
            }

            return NodeState.Failure;
        }
    }
}