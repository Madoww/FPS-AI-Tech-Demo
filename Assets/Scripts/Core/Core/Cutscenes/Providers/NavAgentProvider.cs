using UnityEngine;
using UnityEngine.AI;

namespace FPS.Core.Cutscenes.Providers
{
    public class NavAgentProvider : ICutsceneDataProvider
    {
        [SerializeField]
        private NavMeshAgent agent;

        public NavMeshAgent Agent => agent;
    }
}