using Zenject;

namespace FPS.Game.Flow.Gameplay
{
    using FPS.Common.States;
    using FPS.HI.Input;

    public class GeneralState : BaseState
    {
        private IPlayerInputHandler inputHandler;

        public override void Tick()
        {
            inputHandler.Tick();
        }

        public override void Begin()
        {
            base.Begin();
            inputHandler.Enable();
        }

        [Inject]
        internal void Bind(IPlayerInputHandler inputHandler)
        {
            this.inputHandler = inputHandler;
        }
    }
}