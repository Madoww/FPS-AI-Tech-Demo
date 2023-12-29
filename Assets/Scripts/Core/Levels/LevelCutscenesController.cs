using FPS.Core.Cutscenes.Management;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FPS.Core.Levels
{
    public class LevelCutscenesController : MonoBehaviour
    {
        [SerializeField]
        private bool selfInitialize;
        [SerializeField, ReorderableList]
        private List<LevelCutsceneDefinition> levelCutsceneDefinitions;

        private ICutscenesManager cutscenesManager;

        private void Awake()
        {
            if (selfInitialize)
            {
                Initialize();
            }
        }

        [Inject]
        internal void Bind(ICutscenesManager cutscenesManager)
        {
            this.cutscenesManager = cutscenesManager;
        }

        private void Initialize()
        {
            foreach (LevelCutsceneDefinition levelCutsceneDefinition in levelCutsceneDefinitions)
            {
                var definition = levelCutsceneDefinition.cutsceneDefinition;
                var factory = levelCutsceneDefinition.cutsceneFactory;
                cutscenesManager.RegisterCutscene(definition, factory);
            }
        }
    }
}