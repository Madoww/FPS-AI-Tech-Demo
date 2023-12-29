using UnityEngine;
using UnityEngine.AI;

namespace FPS.AI.Monster
{
    using FPS.AI.Behaviour;
    using FPS.AI.Brain;
    using FPS.AI.Common;
    using FPS.AI.Patrol;
    using System.Collections.Generic;

    public class MonsterBehaviourTreeBuilder : IBehaviourTreeBuilder
    {
        [SerializeField]
        private AiBrain aiBrain;
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
            //var sequenceChase = new Sequence(new List<Node>()
            //{
            //    new ConditionIsPlayerSpotted(aiBrain),
            //    new ActionChase(navMeshAgent)
            //}, OverrideCondition.LowerPriority);
            //
            //var rootSelector = new Selector(new List<Node>()
            //{
            //    sequenceChase,
            //    actionPatrol
            //});
            //
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