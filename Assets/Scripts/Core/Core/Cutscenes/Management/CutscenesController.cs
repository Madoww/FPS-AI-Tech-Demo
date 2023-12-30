using UnityEngine;
using Zenject;

namespace FPS.Core.Cutscenes.Management
{
    public class CutscenesController : MonoBehaviour, ICutscenesController
    {
        private Cutscene activeCutscene;
        private ICutscenesManager cutscenesManager;

        //TODO: Ending cutscene playback.
        public bool IsPlaying => activeCutscene != null;

        public void Play(CutsceneDefinition cutscene)
        {
            activeCutscene = cutscenesManager.LoadCutscene(cutscene);
            activeCutscene.RootNode.Execute();
        }

        [Inject]
        internal void Bind(ICutscenesManager cutscenesManager)
        {
            this.cutscenesManager = cutscenesManager;
        }
    }
}