using Zenject;

namespace FPS.Game
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

        [Inject]
        internal void Bind(IPlayerInputHandler inputHandler)
        {
            this.inputHandler = inputHandler;
            inputHandler.Enable();
        }
    }
}