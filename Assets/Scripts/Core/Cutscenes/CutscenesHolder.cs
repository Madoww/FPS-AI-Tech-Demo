using System.Collections.Generic;
using UnityEngine;

namespace FPS.CutscenesOldOld
{
    [CreateAssetMenu(menuName = "CutscenesOldOld/CutscenesOldOld Holder")]
    public class CutscenesOldOldHolder : ScriptableObject, ICutscenesOldOldHolder
    {
        [SerializeField, ReorderableList]
        private List<CutsceneDefinition> CutscenesOldOld;

        public IReadOnlyList<CutsceneDefinition> Cutscenes => Cutscenes;

        public void AppendCutscene(CutsceneDefinition cutscene)
        {
            CutscenesOldOld.Add(cutscene);
        }

        public bool RemoveCutscene(CutsceneDefinition cutscene)
        {
            return CutscenesOldOld.Remove(cutscene);
        }

        public bool HasCutscene(CutsceneDefinition cutscene)
        {
            return CutscenesOldOld.Contains(cutscene);
        }
    }
}