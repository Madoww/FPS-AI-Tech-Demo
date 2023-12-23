using FPS.Cutscenes;
using System.Collections.Generic;
using Toolbox.Editor;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace FPS.Editor.CutscenesIMGUI
{
    public class CutscenesEditorWindow : EditorWindow
    {
        private readonly InspectorView nodeInspectorView = new InspectorView();

        private CutscenesHolder cutscenesHolder;
        private CutscenesView graphView;
        private CutsceneDefinition selectedCutscene;
        int selectedCutsceneIndex;

        [MenuItem("Tools/CutscenesOldOld/Cutcenes Editor", false)]
        public static void Init()
        {
            GetWindow(typeof(CutscenesEditorWindow), false, $"Cutscenes");
        }

        private void CreateGUI()
        {
            rootVisualElement.Clear();
            var splitView = new TwoPaneSplitView(0, 300.0f, TwoPaneSplitViewOrientation.Horizontal);
            rootVisualElement.Add(splitView);

            var leftPane = new VisualElement();
            splitView.Add(leftPane);
            var rightPane = new VisualElement();
            splitView.Add(rightPane);

            leftPane.Add(new IMGUIContainer(() =>
            {
                using (new EditorGUILayout.VerticalScope(Style.pickerSectionStyle))
                {
                    EditorGUI.BeginChangeCheck();
                    cutscenesHolder = EditorGUILayout.ObjectField(cutscenesHolder, typeof(CutscenesHolder), false) as CutscenesHolder;
                    if (cutscenesHolder == null)
                    {
                        return;
                    }

                    var cutscenes = cutscenesHolder.Cutscenes;
                    var displayName = new GUIContent(cutscenes[selectedCutsceneIndex].displayName);
                    List<string> cutsceneNames = new List<string>();
                    foreach (CutsceneDefinition cutscene in cutscenes)
                    {
                        cutsceneNames.Add(cutscene.displayName);
                    }

                    Rect position = GUILayoutUtility.GetRect(GUIContent.none, Style.pickerSectionStyle);
                    ToolboxEditorGui.DrawSearchablePopup(position, displayName, selectedCutsceneIndex, cutsceneNames.ToArray(),
                    (int index) =>
                    {
                        selectedCutsceneIndex = index;
                        SelectCutscene(cutscenesHolder.Cutscenes[index]);
                        CreateGUI();
                    });

                    EditorGUILayout.Space();

                    if (EditorGUI.EndChangeCheck())
                    {
                        CreateGUI();
                    }

                    if (GUILayout.Button(Style.refreshButtonContent, Style.refreshButtonStyle))
                    {
                        CreateGUI();
                    }

                    nodeInspectorView.DrawGui();
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

        private void SelectCutscene(CutsceneDefinition cutscene)
        {
            selectedCutscene = cutscene;
            UpdateGraph();
        }

        private void UpdateGraph()
        {
            graphView = CreateEmptyGraph();
            graphView.OnNodeSelected += OnSelectNode;
            if (selectedCutscene == null)
            {
                return;
            }

            graphView.PopulateView(selectedCutscene);
        }

        private CutscenesView CreateEmptyGraph()
        {
            var graphView = new CutscenesView()
            {
                name = "Graph",
            };
            graphView.SetupZoom(0.05f, ContentZoomer.DefaultMaxScale);
            graphView.AddManipulator(new ContentDragger());
            graphView.AddManipulator(new RectangleSelector());
            graphView.StretchToParentSize();

            var gridBackground = new GridBackground()
            {
                name = "Grid"
            };

            graphView.Add(gridBackground);
            gridBackground.SendToBack();
            return graphView;
        }

        private void OnSelectNode(CutsceneNodeView node)
        {
            nodeInspectorView.UpdateSelection(node);
        }

        private static class Style
        {
            internal static readonly GUIStyle pickerSectionStyle = new GUIStyle(EditorStyles.inspectorFullWidthMargins);
            internal static readonly GUIStyle refreshButtonStyle = new GUIStyle(EditorStyles.miniButton);
            internal static readonly GUIContent refreshButtonContent = EditorGUIUtility.IconContent("refresh");
        }
    }
}