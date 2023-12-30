using FPS.HI.Input;
using Zenject;

namespace FPS.Game.Flow.Gameplay
{
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