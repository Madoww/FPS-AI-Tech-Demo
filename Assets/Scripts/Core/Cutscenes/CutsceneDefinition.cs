using UnityEngine;

namespace FPS.CutscenesOldOld
{
    [CreateAssetMenu(menuName = "CutscenesOldOld/Cutscene Definition")]
    public class CutsceneDefinition : ScriptableObject
    {
        public string displayName;
        [ReorderableList]
        public CutsceneNodeDefinition[] nodes;
    }
}