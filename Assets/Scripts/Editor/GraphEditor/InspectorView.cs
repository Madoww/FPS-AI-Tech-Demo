using UnityEngine;

namespace FPS.Editor.GraphEditor
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