using FPS.AI.Behaviour.Data;
using UnityEngine;

namespace FPS.AI.Behaviour.Nodes
{

    public class ActionLog : BehaviourNode<ActionLogData>
    {
        public override NodeState Evaluate(BehaviourTreeState treeState)
        {
            Debug.Log(Data.message);
            return NodeState.Running;
        }
    }
}