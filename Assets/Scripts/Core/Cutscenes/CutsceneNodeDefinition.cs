using UnityEngine;

namespace FPS.Cutscenes
{
    [CreateAssetMenu(menuName = "Cutscenes/Node")]
    public class CutsceneNodeDefinition : ScriptableObject
    {
        public string displayName;
        public CutsceneNodeDefinition nextNode;
    }
}