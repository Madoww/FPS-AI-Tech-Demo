using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TestEditorWindow : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Window/UI Toolkit/TestEditorWindow")]
    public static void ShowExample()
    {
        TestEditorWindow wnd = GetWindow<TestEditorWindow>();
        wnd.titleContent = new GUIContent("TestEditorWindow");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }
}
