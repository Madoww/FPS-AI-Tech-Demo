using UnityEngine;
using UnityEngine.UIElements;

namespace FPS.Editor.Cutscenes
{
    using Editor = UnityEditor.Editor;

    public class InspectorView : VisualElement
    {
        private Editor editor;

        public new class UxmlFactory : UxmlFactory<InspectorView, VisualElement.UxmlTraits>
        { }

        public InspectorView()
        { }

        internal void UpdateSelection(CutsceneNodeView nodeView)
        {
            Clear();
            Object.DestroyImmediate(editor);
            editor = Editor.CreateEditor(nodeView.NodeDefinition);
            IMGUIContainer container = new IMGUIContainer(() =>
            {
                editor.OnInspectorGUI();
            });
            Add(container);
        }
    }
}