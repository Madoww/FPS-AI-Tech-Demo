using System;

namespace FPS.Game.Flow
{
    public class MasterState : BaseState
    {
        private BaseStateMachine stateMachine;

        public BaseState CurrentState => stateMachine.CurrentState;

        public MasterState(BaseState[] nestedStates)
        {
            stateMachine = new BaseStateMachine(nestedStates);
        }

        public override void Begin()
        {
            base.Begin();
            stateMachine.Start();
        }

        public override void Close()
        {
            stateMachine.Stop();
            base.Close();
        }

        public override void Tick()
        {
            base.Tick();
            stateMachine.Tick();
        }

        public bool TryChangeState(Type stateType)
        {
            return stateMachine.ChangeState(stateType);
        }
    }
}