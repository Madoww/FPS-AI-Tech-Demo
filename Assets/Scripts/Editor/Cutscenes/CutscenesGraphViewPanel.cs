using FPS.Core.Cutscenes;
using FPS.Editor.GraphEditor;
using UnityEditor;
using UnityEngine.UIElements;

namespace FPS.Editor.Cutscenes
{
    public class CutscenesGraphViewPanel : GraphViewPanel
    {
        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            var types = TypeCache.GetTypesDerivedFrom<CutsceneNodeData>();
            foreach (var type in types)
            {
                evt.menu.AppendAction($"[{type.Name}]", (action) => CreateNodeDefinition(type));
            }
        }
    }
}