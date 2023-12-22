using UnityEngine.UIElements;

namespace FPS.Editor.Cutscenes
{
    public class SplitView : TwoPaneSplitView
    {
        public new class UxmlFactory : UxmlFactory<SplitView, TwoPaneSplitView.UxmlTraits>
        { }
    }
}