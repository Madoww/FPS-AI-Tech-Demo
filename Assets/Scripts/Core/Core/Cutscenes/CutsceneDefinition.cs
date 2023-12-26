using FPS.Common;
using UnityEngine;

namespace FPS.Core.Cutscenes
{
    [CreateAssetMenu(menuName = "Cutscenes/Cutscene Definition")]
    public class CutsceneDefinition : ScriptableNodesHolder<CutsceneNodeData>
    {
        public string displayName;
    }
}