using System.Collections.Generic;

namespace FPS.AI.Patrol
{
    public interface IPatrolDataProvider
    {
        public List<PatrolArea> GetPatrolData();
    }
}