using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;

    public class MonsterBehaviourTreeBuilder : IBehaviourTreeBuilder
    {
        [SerializeField]
        private NavMeshAgent navMeshAgent;

        public BehaviourTree Build()
        {
            SequenceNode searchSequence = new SequenceNode(new List<INode>()
            {
                new ActionSearch(),
                new ActionChase(navMeshAgent)
            });

            BehaviourTree tree = new BehaviourTree(searchSequence);
            return tree;
        }
    }
}