using UnityEngine;

namespace FPS.CutscenesOldOld
{
    [CreateAssetMenu(menuName = "CutscenesOldOld/Node")]
    public class CutsceneNodeDefinition : ScriptableObject
    {
        public string displayName;
        public CutsceneNodeDefinition nextNode;
    }
}