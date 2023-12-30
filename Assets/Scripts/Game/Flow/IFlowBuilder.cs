using System.Collections.Generic;

namespace FPS.Game.Flow
{
    public interface IFlowBuilder
    {
        MasterState[] Build(out List<BaseState> linkedStates);
    }
}