using System.Collections.Generic;
using UnityEngine;
using FPS.Common;

namespace FPS.Cutscenes
{
    [CreateAssetMenu(menuName = "Cutscenes/Node")]
    public class CutsceneNodeDefinition : ScriptableNode
    {
        public string description;
    }
}