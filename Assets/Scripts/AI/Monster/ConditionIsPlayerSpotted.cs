namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;
    using FPS.AI.Brain;

    public class ConditionIsPlayerSpotted : Node
    {
        private AiBrain aiBrain;
        private float certaintyThreshold = 0.2f;

        public override OverrideCondition OverrideCondition => OverrideCondition.LowerPriority;

        public ConditionIsPlayerSpotted(AiBrain aiBrain)
        {
            this.aiBrain = aiBrain;
        }

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            var data = aiBrain.MostCertainData;
            if (data == null)
            {
                return NodeState.Failure;
            }

            if (data.certainty > certaintyThreshold)
            {
                return NodeState.Success;
            }

            treeState.SetData(Blackboard.POSITION_OF_INTEREST, data.position);
            return NodeState.Failure;
        }
    }
}