using FPS.AI.Behaviour;
using FPS.Editor.GraphEditor;
using UnityEditor;
using UnityEngine.UIElements;

namespace FPS.Editor.BehaviourTree
{
    public class BehaviourTreeGraphViewPanel : GraphViewPanel
    {
        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            var types = TypeCache.GetTypesDerivedFrom<BehaviourNodeData>();
            foreach (var type in types)
            {
                evt.menu.AppendAction($"[{type.Name}]", (action) => CreateNodeDefinition(type));
            }
        }
    }
}