using System.Collections.Generic;
using UnityEngine;

namespace FPS.AI.Behaviour
{
    [CreateAssetMenu(menuName = "FPS/Behaviour/Node Implementations Holder")]
    public class NodeImplementationsHolder : ScriptableObject
    {
        [SerializeReference, ReferencePicker, ReorderableList]
        private List<IBehaviourNode> behaviourNodes;

        public IReadOnlyList<IBehaviourNode> NodeImplementations => behaviourNodes;
    }
}