using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Patrol
{
    public class PatrolDataProvider : MonoBehaviour, IPatrolDataProvider
    {
        [SerializeField]
        private List<PatrolAreaContext> patrolData;

        public List<PatrolAreaContext> GetPatrolData()
        {
            return patrolData;
        }
    }
}