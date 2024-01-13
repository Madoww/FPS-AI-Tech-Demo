using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core.Cutscenes
{
    [CreateAssetMenu(menuName = "FPS/Cutscenes/Cutscenes Holder")]
    public class CutscenesHolder : ScriptableObject, ICutscenesHolder
    {
        [SerializeField, ReorderableList]
        private List<CutsceneDefinition> cutscenes;

        public IReadOnlyList<CutsceneDefinition> Cutscenes => cutscenes;

        public void AppendCutscene(CutsceneDefinition cutscene)
        {
            cutscenes.Add(cutscene);
        }

        public bool RemoveCutscene(CutsceneDefinition cutscene)
        {
            return cutscenes.Remove(cutscene);
        }

        public bool HasCutscene(CutsceneDefinition cutscene)
        {
            return cutscenes.Contains(cutscene);
        }
    }
}