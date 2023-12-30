using FPS.Core.Cutscenes.Management;
using Zenject;

namespace FPS.Game.Flow.Gameplay
{
    public class CutsceneState : BaseState
    {
        private ICutscenesController cutscenesController;

        public override bool WantsToBegin()
        {
            return cutscenesController.IsPlaying;
        }

        public override bool WantsToClose()
        {
            return !cutscenesController.IsPlaying;
        }

        [Inject]
        internal void Bind(ICutscenesController cutscenesController)
        {
            this.cutscenesController = cutscenesController;
        }
    }
}