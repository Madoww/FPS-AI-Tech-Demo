using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
            //var actionPatrol = new ActionPatrol(patrolDataProvider.GetPatrolData(), selfTransform, navMeshAgent);

            var sequenceSearch = new Sequence(new List<Node>()
            {
                new ActionSearch(playerTransform),
                new ActionChase(navMeshAgent)
            });

            ActionLog logTorchEquipped = new ActionLog("Torch Equipped!");
            ActionLog logTorchNotEquipped = new ActionLog("Torch Not Equipped!");
            var selectorTest = new Selector(new List<Node>()
            {
                new ConditionIsTorchEquipped(logTorchEquipped),
                logTorchNotEquipped
            });

            BehaviourTree tree = new BehaviourTree(selectorTest);
            return tree;
        }
    }
}