using FPS.Core.Cutscenes;
using FPS.Core.Cutscenes.Management;
using UnityEngine;
using Zenject;

namespace FPS.Core.Levels
{
    public class LevelCutsceneTrigger : MonoBehaviour
    {
        [SerializeField]
        private CutsceneDefinition cutsceneDefinition;

        private ICutscenesController cutscenesController;

        private void OnTriggerEnter(Collider other)
        {
            //TODO: Add check if player.
            Debug.Log("Cutscene triggered");
            cutscenesController.Play(cutsceneDefinition);
        }

        [Inject]
        internal void Bind(ICutscenesController cutscenesController)
        {
            this.cutscenesController = cutscenesController;
        }
    }
}