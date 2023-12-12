using System;

namespace FPS.Common.States
{
    public interface IStateMachine
    {
        BaseState CurrentState { get; }

        event Action<BaseState> OnStateChanged;

        void Start();
        void Tick();
        void ChangeState(Type newStateType);
    }
}