using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using FPS.Common;

namespace FPS.Cutscenes
{
    [CreateAssetMenu(menuName = "Cutscenes/Cutscene Definition")]
    public class CutsceneDefinition : ScriptableNodesHolder
    {
        public string displayName;
    }
}