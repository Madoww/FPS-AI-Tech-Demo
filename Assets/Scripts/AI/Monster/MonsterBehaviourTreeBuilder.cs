using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;
    using FPS.AI.Patrol;

    public class MonsterBehaviourTreeBuilder : IBehaviourTreeBuilder
    {
        [SerializeField]
        private NavMeshAgent navMeshAgent;
        [SerializeField]
        private Transform playerTransform;
        [SerializeField]
        private Transform selfTransform;
        [SerializeField]
        private PatrolDataProvider patrolDataProvider;

        public BehaviourTree Build()
        {
            //var actionPatrol = new ActionPatrol(patrolDataProvider.GetPatrolData(), selfTransform, navMeshAgent);

            var sequenceSearch = new Sequence(new List<INode>()
            {
                new ActionSearch(playerTransform),
                new ActionChase(navMeshAgent)
            });

            BehaviourTree tree = new BehaviourTree(sequenceSearch);
            return tree;
        }
    }
}