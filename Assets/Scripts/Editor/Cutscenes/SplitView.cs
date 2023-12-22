using UnityEditor;
using UnityEngine.UIElements;

namespace FPS.Editor.Cutscenes
{
    public class SplitView : TwoPaneSplitView
    {
        public new class UxmlFactory : UxmlFactory<SplitView, TwoPaneSplitView.UxmlTraits>
        { }

        public SplitView()
        {
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/Editor/Cutscenes/CutscenesEditor.uss");
            styleSheets.Add(styleSheet);
        }
    }
}