using FPS.AI.Behaviour;
using FPS.AI.Brain;
using FPS.AI.Monster.Data;

namespace FPS.AI.Monster
{

    public class ConditionIsPlayerSpotted : BehaviourNode<ConditionIsPlayerSpottedData>
    {
        private AiBrain aiBrain;
        private float certaintyThreshold = 0.2f;

        public override OverrideCondition OverrideCondition => OverrideCondition.LowerPriority;

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