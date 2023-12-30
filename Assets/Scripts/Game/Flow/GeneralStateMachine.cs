namespace FPS.Game.Flow
{
    using System.Collections.Generic;

    public class GeneralStateMachine : BaseStateMachine
    {
        public GeneralStateMachine(List<BaseState> states, BaseState startState) : base(states, startState)
        {
        }
    }
}