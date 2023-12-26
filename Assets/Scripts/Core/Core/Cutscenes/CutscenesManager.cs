using UnityEngine;

namespace FPS.Core.Cutscenes
{
    public class CutscenesManager : MonoBehaviour, ICutscenesManager
    {
        [SerializeReference, ReferencePicker]
        private ICutscenesFactory factory;

        [SerializeField]
        private CutsceneDefinition defaultDefinition;

        public Cutscene LoadCutscene(CutsceneDefinition definition)
        {
            return factory.CreateCutscene(definition);
        }

        private void Awake()
        {
            LoadCutscene(defaultDefinition);
        }
    }
}