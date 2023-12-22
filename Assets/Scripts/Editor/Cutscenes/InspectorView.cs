using UnityEngine.UIElements;

namespace FPS.Editor.Cutscenes
{
    public class InspectorView : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<InspectorView, VisualElement.UxmlTraits>
        { }

        public InspectorView()
        { }
    }
}