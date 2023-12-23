using UnityEngine;

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

        internal void UpdateSelection(CutsceneNodeView nodeView)
        {
            Object.DestroyImmediate(editor);
            editor = Editor.CreateEditor(nodeView.NodeDefinition);
        }
    }
}