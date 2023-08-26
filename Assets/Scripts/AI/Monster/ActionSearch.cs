using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;
    using FPS.AI.Common;

    public class ActionSearch : INode
    {
        private Transform target;

        //TODO: Rework temporary testing solution.
        public ActionSearch(Transform target)
        {
            this.target = target;
        }

        public NodeState Evaluate(Dictionary<string, object> data)
        {
            Vector3 targetPosition = target.position;
            if (!data.TryAdd(Blackboard.POSITION_OF_INTEREST, targetPosition))
            {
                data[Blackboard.POSITION_OF_INTEREST] = targetPosition;
            }

            return NodeState.Success;
        }
    }
}