using UnityEngine;
using FPS.Editor.GraphEditor;

namespace FPS.Editor.Cutscenes
{
    using Editor = UnityEditor.Editor;

    public class InspectorView
    {
        private Editor editor;

        public InspectorView()
        { }

        public void DrawGui()
        {
            if (editor == null)
            {
                return;
            }

            editor.OnInspectorGUI();
        }

        internal void UpdateSelection(GraphNodeView nodeView)
        {
            Object.DestroyImmediate(editor);
            editor = Editor.CreateEditor(nodeView.NodeDefinition);
        }
    }
}