using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace FPS.Editor.Cutscenes
{
    public class CutscenesView : GraphView
    {
        public new class UxmlFactory : UxmlFactory<CutscenesView, GraphView.UxmlTraits>
        { }

        public CutscenesView()
        {
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/Editor/Cutscenes/CutscenesEditor.uss");
            styleSheets.Add(styleSheet);
            this.AddManipulator(new ContentZoomer());
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            Insert(0, new GridBackground());
        }
    }
}