using System.Collections;
using System.Collections.Generic;
using FPS.Core.Cutscenes;
using UnityEngine;

namespace FPS.Core.Cutscenes
{
    [CreateAssetMenu(menuName = "FPS/Cutscenes/Node Implementations Holder")]
    public class NodeImplementationsHolder : ScriptableObject
    {
        [SerializeReference, ReferencePicker, ReorderableList]
        private List<ICutsceneNode> cutsceneNodes;

        public IReadOnlyList<ICutsceneNode> ImplementationNodes => cutsceneNodes;
    }
}