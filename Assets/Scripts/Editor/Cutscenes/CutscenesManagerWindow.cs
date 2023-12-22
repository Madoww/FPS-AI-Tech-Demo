using FPS.Common;
using FPS.Cutscenes;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace FPS.Editor.Cutscenes
{
    public class CutscenesManagerWindow : EditorWindow
    {
        private static readonly GraphSettings graphSettings = new GraphSettings(350.0f, 100.0f);

        private ICutscenesHolder cutscenesHolder;
        private StateMachineGraphView graphView;
        private CutsceneDefinition selectedCutscene;

        [MenuItem("Tools/Cutscenes/Cutcenes Editor", false)]
        public static void Init()
        {
            GetWindow(typeof(CutscenesManagerWindow), false, $"State Machine");
        }

        private void CreateGUI()
        {
            rootVisualElement.Clear();
            var splitView = new TwoPaneSplitView(0, 300.0f, TwoPaneSplitViewOrientation.Horizontal);
            rootVisualElement.Add(splitView);
            cutscenesHolder = AssetUtility.GetFirstAsset<CutscenesHolder>();

            var leftPane = new VisualElement();
            splitView.Add(leftPane);
            var rightPane = new VisualElement();
            splitView.Add(rightPane);

            leftPane.Add(new IMGUIContainer(() =>
            {
                using (new EditorGUILayout.VerticalScope(Style.pickerSectionStyle))
                {
                    EditorGUI.BeginChangeCheck();
                    var cutscenes = cutscenesHolder.Cutscenes;
                    foreach (CutsceneDefinition cutscene in cutscenes)
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