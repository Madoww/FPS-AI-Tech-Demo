using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;
    using FPS.AI.Common;
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
            ActionPatrol actionPatrol = new ActionPatrol(patrolDataProvider.GetPatrolData(), selfTransform, navMeshAgent);

            SequenceNode sequenceSearch = new SequenceNode(new List<INode>()
            {
                new ActionSearch(playerTransform),
                new ActionChase(navMeshAgent)
            });

            BehaviourTree tree = new BehaviourTree(actionPatrol);
            return tree;
        }

        [Inject]
        internal void Bind(IPatrolDataProvider patrolDataProvider)
        {
            //this.patrolDataProvider = patrolDataProvider;
        }
    }
}