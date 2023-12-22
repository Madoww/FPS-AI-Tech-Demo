using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace FPS.Editor.Cutscenes
{
    public class CutscenesEditor : EditorWindow
    {
        [SerializeField]
        private VisualTreeAsset m_VisualTreeAsset = default;

        [MenuItem("Tools/CutscenesEditor")]
        public static void ShowExample()
        {
            CutscenesEditor wnd = GetWindow<CutscenesEditor>();
            wnd.titleContent = new GUIContent("CutscenesEditor");
        }

        public void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;

            // Instantiate UXML
            //root.styleSheets.Add(labelFromUXML);
            VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
            root.Add(labelFromUXML);

            var childCount = labelFromUXML.childCount;
            for (int i = 0; i < childCount; i++)
            {
                root.Add(labelFromUXML.ElementAt(i));
            }
        }
    }
}