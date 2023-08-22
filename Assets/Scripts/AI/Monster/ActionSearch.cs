using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;

    public class ActionSearch : INode
    {
        //TODO: Rework temporary testing solution.
        [SerializeField]
        private Transform target;

        public NodeState Evaluate(Dictionary<string, object> data)
        {
            data.Add(Blackboard.POSITION_OF_INTEREST, target.transform);

            return NodeState.Success;
        }
    }
}