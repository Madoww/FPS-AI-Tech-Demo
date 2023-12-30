using System;

namespace FPS.Game.Flow
{
    public interface IStateMachine
    {
        BaseState CurrentState { get; }

        event Action<BaseState> OnStateChanged;

        void Start();
        void Stop();
        void Tick();
        bool ChangeState(BaseState state);
        bool ChangeState(Type newStateType);
    }
}