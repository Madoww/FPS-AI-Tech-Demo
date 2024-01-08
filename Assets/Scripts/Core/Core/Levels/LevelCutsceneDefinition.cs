using FPS.Core.Cutscenes;
using UnityEngine;

namespace FPS.Core.Levels
{
    public class LevelCutsceneDefinition : MonoBehaviour
    {
        public CutsceneDefinition cutsceneDefinition;
        [SerializeReference, ReferencePicker]
        public ICutsceneFactory cutsceneFactory;
    }
}