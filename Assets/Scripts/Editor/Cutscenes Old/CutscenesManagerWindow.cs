using FPS.Common;
using FPS.CutscenesOldOld;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace FPS.Editor.CutscenesOldOld
{
    public class CutscenesManagerWindow : EditorWindow
    {
        private static readonly GraphSettings graphSettings = new GraphSettings(350.0f, 100.0f);

        private ICutscenesOldOldHolder CutscenesOldOldHolder;
        private StateMachineGraphView graphView;
        private CutsceneDefinition selectedCutscene;

        [MenuItem("Tools/CutscenesOldOld/Cutcenes Editor", false)]
        public static void Init()
        {
            GetWindow(typeof(CutscenesManagerWindow), false, $"State Machine");
        }

        private void CreateGUI()
        {
            rootVisualElement.Clear();
            var splitView = new TwoPaneSplitView(0, 300.0f, TwoPaneSplitViewOrientation.Horizontal);
            rootVisualElement.Add(splitView);
            CutscenesOldOldHolder = AssetUtility.GetFirstAsset<CutscenesOldOldHolder>();

            var leftPane = new VisualElement();
            splitView.Add(leftPane);
            var rightPane = new VisualElement();
            splitView.Add(rightPane);

            leftPane.Add(new IMGUIContainer(() =>
            {
                using (new EditorGUILayout.VerticalScope(Style.pickerSectionStyle))
                {
                    EditorGUI.BeginChangeCheck();
                    var CutscenesOldOld = CutscenesOldOldHolder.Cutscenes;
                    foreach (CutsceneDefinition cutscene in CutscenesOldOld)
                    {
                        if (GUILayout.Button(cutscene.displayName))
                        {
                            selectedCutscene = cutscene;
                            UpdateGraph();
                        }
                    }
                    //stateMachineType = (StateMachineType)EditorGUILayout.EnumPopup("Level", stateMachineType);
                    if (EditorGUI.EndChangeCheck())
                    {
                        CreateGUI();
                    }

                    if (GUILayout.Button(Style.refreshButtonContent, Style.refreshButtonStyle))
                    {
                        CreateGUI();
                    }
                }
            }));

            //var stateMachine = GetStateMachine();
            //PickStateMachine(stateMachine);
            //if (stateMachine == null)
            //{
            //    rightPane.Add(new HelpBox("State Machine not found", HelpBoxMessageType.Warning));
            //}
            //else
            //{
            UpdateGraph();
            rightPane.Add(graphView);
            rightPane.Add(new IMGUIContainer(() =>
             {
                 using (new EditorGUILayout.HorizontalScope())
                 {
                     if (GUILayout.Button("Create Node"))
                     {
                         //graphView.AddElement(new CutsceneNode())
                     }
                 }
             }));
            //}
        }

        private void OnDisable()
        {
            //PickStateMachine(null);
        }

        private void UpdateGraph()
        {
            graphView = CutsceneGraphUtility.CreateGraph(selectedCutscene, in graphSettings);
        }

        private static class Style
        {
            internal static readonly GUIStyle pickerSectionStyle = new GUIStyle(EditorStyles.inspectorFullWidthMargins);
            internal static readonly GUIStyle refreshButtonStyle = new GUIStyle(EditorStyles.miniButton);
            internal static readonly GUIContent refreshButtonContent = EditorGUIUtility.IconContent("refresh");
        }
    }
}