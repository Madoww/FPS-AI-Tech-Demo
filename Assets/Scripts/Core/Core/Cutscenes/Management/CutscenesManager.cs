using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Cutscenes.Management
{
    public class CutscenesManager : MonoBehaviour, ICutscenesManager
    {
        private readonly Dictionary<CutsceneDefinition, ICutsceneFactory> factoryByDefinition = new Dictionary<CutsceneDefinition, ICutsceneFactory>();

        public void RegisterCutscene(CutsceneDefinition definition, ICutsceneFactory factory)
        {
            factoryByDefinition.Add(definition, factory);
        }

        public Cutscene LoadCutscene(CutsceneDefinition definition)
        {
            if (!factoryByDefinition.TryGetValue(definition, out ICutsceneFactory factory))
            {
                Debug.LogError($"No factory found for cutscene {definition.displayName}");
                return null;
            }

            return factory.CreateCutscene(definition);
        }
    }
}