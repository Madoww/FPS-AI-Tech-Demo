using UnityEngine;

namespace FPS.Core.Cutscenes.Management
{
    public class CutscenesManager : MonoBehaviour, ICutscenesManager
    {
        [SerializeReference, ReferencePicker]
        private ICutscenesFactory factory;

        public Cutscene LoadCutscene(CutsceneDefinition definition)
        {
            return factory.CreateCutscene(definition);
        }
    }
}