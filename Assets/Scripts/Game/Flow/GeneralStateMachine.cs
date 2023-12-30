namespace FPS.Game.Flow
{
    using System.Collections.Generic;

    public class GeneralStateMachine : BaseStateMachine
    {
        public GeneralStateMachine(IReadOnlyList<BaseState> states, BaseState startState = null) : base(states, startState)
        { }
    }
}