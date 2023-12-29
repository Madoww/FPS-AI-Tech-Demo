using FPS.Core.Cutscenes;
using System;
using UnityEngine;

namespace FPS.Core.Levels
{
    [Serializable]
    public class LevelCutsceneDefinition : MonoBehaviour
    {
        public CutsceneDefinition cutsceneDefinition;
        [SerializeReference, ReferencePicker]
        public ICutsceneFactory cutsceneFactory;
    }
}