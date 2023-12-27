using UnityEngine;
using Zenject;

namespace FPS.Core.Cutscenes.Management
{
    public class CutscenesController : MonoBehaviour, ICutscenesController
    {
        [SerializeField]
        private CutsceneDefinition defaultCutscene;

        private Cutscene activeCutscene;
        private ICutscenesManager cutscenesManager;

        private void Awake()
        {
            Play(defaultCutscene);
        }

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