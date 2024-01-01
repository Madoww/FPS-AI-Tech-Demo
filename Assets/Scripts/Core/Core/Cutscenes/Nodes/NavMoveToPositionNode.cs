using FPS.Common;
using FPS.Core.Cutscenes.Data;
using FPS.Core.Cutscenes.Providers;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace FPS.Core.Cutscenes.Nodes
{
    public class NavMoveToPositionNode : CutsceneNode<NavMoveToPositionData>
    {
        private Vector3 targetPosition;
        private NavMeshAgent navMeshAgent;

        public override void Setup(IDataProvidersHandler providersHandler)
        {
            base.Setup(providersHandler);
            if (!providersHandler.TryGetProvider<NavAgentProvider>(out var navAgentProvider))
            {
                Debug.LogWarning($"{nameof(NavAgentProvider)} not found.");
                return;
            }

            if (!providersHandler.TryGetProvider<TransformProvider>(out var transformProvider))
            {
                Debug.LogWarning($"{nameof(TransformProvider)} not found.");
                return;
            }

            navMeshAgent = navAgentProvider.Agent;
            targetPosition = transformProvider.Transform.position;
        }

        public override void Execute()
        {
            navMeshAgent.SetDestination(targetPosition);
            CoroutineRunner.StartCoroutine(WaitToComplete());
        }

        private IEnumerator WaitToComplete()
        {
            while (navMeshAgent.pathPending || navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
            {
                yield return null;
            }

            Complete();
        }
    }
}