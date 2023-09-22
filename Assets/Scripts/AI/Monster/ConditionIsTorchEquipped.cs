using UnityEngine;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;

    public class ConditionIsTorchEquipped : Node
    {
        private bool isFlagEquipped = false;
        private Node child;

        public override OverrideCondition OverrideCondition => OverrideCondition.LowerPriority;

        public ConditionIsTorchEquipped(Node childNode)
        {
            child = childNode;
        }

        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                ToggleIsEquipped();
            }

            //Debug.Log("Check: Is equipped?");

            if (isFlagEquipped)
            {
                return child.Evaluate(treeState);
            }

            return NodeState.Failure;
        }

        private void ToggleIsEquipped()
        {
            if (isFlagEquipped)
            {
                isFlagEquipped = false;
                return;
            }

            isFlagEquipped = true;
        }
    }
}