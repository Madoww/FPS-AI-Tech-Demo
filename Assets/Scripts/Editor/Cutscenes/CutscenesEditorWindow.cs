using FPS.Cutscenes;
using System.Collections.Generic;
using Toolbox.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using FPS.Editor.GraphEditor;

namespace FPS.Editor.Cutscenes
{
    public class CutscenesEditorWindow : EditorWindow
    {
        private readonly InspectorView nodeInspectorView = new InspectorView();

        private CutscenesHolder cutscenesHolder;
        private GraphViewPanel graphView;
        private CutsceneDefinition selectedCutscene;
        private int selectedCutsceneIndex;

        [MenuItem("Tools/Cutcenes Editor", false)]
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

            if (cutscenesHolder == null)
            {
                rightPane.Add(new HelpBox($"{nameof(CutscenesHolder)} not found.", HelpBoxMessageType.Warning));
            }
            else if (selectedCutscene == null)
            {
                rightPane.Add(new HelpBox($"{nameof(CutsceneDefinition)} not selected.", HelpBoxMessageType.Warning));
            }
            else
            {
                UpdateGraph();
                rightPane.Add(graphView);
            }
        }

        private void SelectCutscene(CutsceneDefinition cutscene)
        {
            selectedCutscene = cutscene;
            UpdateGraph();
        }

        private void UpdateGraph()
        {
            if (graphView == null)
            {
                graphView = GraphViewUtility.CreateGraphView(selectedCutscene);
                graphView.OnNodeSelected += OnSelectNode;
                return;
            }

            graphView = GraphViewUtility.CreateGraphView(selectedCutscene, graphView);
        }

        private void OnSelectNode(GraphNodeView node)
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