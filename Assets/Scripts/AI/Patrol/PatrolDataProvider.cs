using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Patrol
{
    public class PatrolDataProvider : MonoBehaviour, IPatrolDataProvider
    {
        [SerializeField]
        private List<PatrolArea> patrolData;

        public List<PatrolArea> GetPatrolData()
        {
            return patrolData;
        }
    }
}