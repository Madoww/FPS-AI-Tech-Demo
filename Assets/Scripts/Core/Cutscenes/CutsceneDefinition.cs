using UnityEngine;

namespace FPS.Cutscenes
{
    [CreateAssetMenu(menuName = "Cutscenes/Cutscene Definition")]
    public class CutsceneDefinition : ScriptableObject
    {
        public string displayName;
        [ReorderableList]
        public CutsceneNodeDefinition[] nodes;
    }
}