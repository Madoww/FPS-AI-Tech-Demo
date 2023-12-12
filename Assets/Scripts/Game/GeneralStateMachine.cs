namespace FPS.Game
{
    using FPS.Common.States;
    using System.Collections.Generic;

    public class GeneralStateMachine : BaseStateMachine
    {
        public GeneralStateMachine(List<BaseState> states, BaseState startState) : base(states, startState)
        {
        }
    }
}